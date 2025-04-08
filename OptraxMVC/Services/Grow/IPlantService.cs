﻿using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models;
using OptraxDAL.Models.Grow;
using OptraxMVC.Areas.Grow.Models;
using OptraxMVC.Models;

namespace OptraxMVC.Services.Grow
{
    public interface IPlantService
    {
        Task<List<object>> GetPlantNodesAsync(string? comName = null);
        Task<Plant> LoadCreate(string type, string parentId);
        Task<ResponseVM> CreateAsync(Plant plant, string userId);
        Task<ResponseVM> CreateGroupAsync(PlantTypeGroup group);
    }

    [Authorize]
    public class PlantService(OptraxContext context, ICurrentUserService user) : IPlantService
    {
        private readonly OptraxContext db = context;
        private readonly string UserId = user.UserId;

        public async Task<ResponseVM> CreateGroupAsync(PlantTypeGroup group)
        {
            try
            {
                var dbGroup = await db.PlantTypeGroups.FirstOrDefaultAsync(g => g.Name == group.Name);
                if (dbGroup != null)
                {
                    return new ResponseVM("Plant group already exists.");
                }
                await db.PlantTypeGroups.AddAsync(group);
                await db.SaveChangesAsync();

                object grpNode = new
                {
                    id = group.Name,
                    parent = group.PlantType,
                    text = group.Name,
                    type = "cn",
                    state = new { opened = true, selected = false },
                };
                return new ResponseVM(grpNode);
            }
            catch (Exception ex)
            {
                return new ResponseVM(ex.Message);
            }
        }

        [Authorize]
        public async Task<List<object>> GetPlantNodesAsync(string? comName = null)
        {
            List<object> nodes = [];

            if (!string.IsNullOrEmpty(comName))
            {
                return await GetChildNodes(comName);
            }

            try
            {
                var plantTypes = Enum.GetNames(typeof(Enums.PlantType));

                var typeComName = await db.PlantTypeGroups.GroupBy(p => p.PlantType).ToDictionaryAsync(g => g.Key, g => g.Select(p => p.Name).ToList());

                foreach (var type in plantTypes)
                {
                    nodes.Add(new
                    {
                        id = type,
                        parent = "#",
                        text = type + "s",
                        type = "pt",
                        state = new { opened = true, selected = false },
                    });

                    var comNameNodes = typeComName.Where(s => s.Key == type)
                                                  .SelectMany(s => s.Value.Select(c => new
                                                  {
                                                      id = c,
                                                      parent = type,
                                                      text = c,
                                                      type = "cn",
                                                      children = true,
                                                      state = new { opened = false, selected = false },
                                                  })).ToList();
                    nodes.AddRange(comNameNodes);
                }

                return nodes;
            }
            catch (Exception ex)
            {
                return nodes;
            }
        }

        public async Task<List<object>> GetChildNodes(string comName)
        {
            try
            {
                var plants = await db.Plants.Where(p => p.CommonName == comName && (p.UserId == null || p.UserId == UserId))
                                            .Include(p => p.ChildrenP1)
                                            .Include(p => p.ChildrenP2).ToListAsync();

                var species = plants.Where(p => p.TaxonType == "Species").Select(p => new
                {
                    id = p.Id,
                    parent = comName,
                    text = p.CustomName ?? p.CommonName ?? p.ScientificName ?? "No Name",
                    data = new { id = p.Id, type = p.PlantType, taxon = p.TaxonType },

                    children = p.AllChildren.Count > 0 ? p.AllChildren.OrderBy(c => c.TaxonType).ThenBy(c => c.CustomName ?? c.CultivarName ?? c.CommonName ?? c.ScientificName)
                    .Select(c => new
                    {
                        id = c.Id,
                        parent = p.Id,
                        text = c.CustomName ?? c.CultivarName ?? c.CommonName ?? c.ScientificName,
                        type = c.TaxonType,
                        data = new { id = c.Id, type = c.PlantType, taxon = c.TaxonType },
                        children = false

                    }).ToList<object>() : null,

                }).ToList<object>();

                return species;
            }
            catch (Exception ex)
            {
                return [];
            }
        }

        [Authorize]
        public async Task<Plant> LoadCreate(string type, string parentId)
        {
            var ignoreCase = StringComparison.CurrentCultureIgnoreCase;
            var title = LetterCasing.Title;

            List<PlantTrait> traits = [.. (await db.TraitDefinitions.Where(t => t.AlwaysShow == true).Include(t => t.Options).ToListAsync()).Select(t => new PlantTrait(t))];

            int parId = int.TryParse(parentId, out int id) ? id : 0;

            Plant? parent = parId > 0 ? await db.Plants.FindAsync(parId) : null;

            if (type.Equals("species", ignoreCase))
            {
                return new(traits) { PlantType = parentId.ApplyCase(title), TaxonType = "Species" };
            }
            else if (type.Equals("variety", ignoreCase) || type.Equals("cultivar", ignoreCase))
            {
                string taxon = type.Equals("variety", ignoreCase) ? "Variety" : "Cultivar";

                if (parent == null)
                {
                    return new(traits) { PlantType = parentId.ApplyCase(title), TaxonType = taxon };
                }

                return new(traits)
                {
                    TaxonType = taxon,
                    PlantType = parent?.PlantType ?? "",
                    Parent1Id = parId,
                    Genus = parent?.Genus,
                    Species = parent?.Species,
                    CommonName = parent?.CommonName
                };
            }

            return new(traits);
        }

        //[Authorize]
        public async Task<ResponseVM> CreateAsync(Plant plant, string userId)
        {
            try
            {
                bool hasNew = false;
                CheckTraits(plant, ref hasNew);

                List<PlantTrait> traits = plant.Profile.Traits;

                if (!hasNew)
                {
                    var dbProfile = await db.PlantProfiles.Include(p => p.Traits)
                                                          .ThenInclude(t => t.SelectedOptions)
                                                          .FirstOrDefaultAsync(p => p.Traits.Count == traits.Count &&
                                                                                   !p.Traits.Except(traits, new PlantTraitComparer()).Any());
                    if (dbProfile != null)
                    {
                        plant.ProfileId = dbProfile.Id;
                        plant.Profile = dbProfile;
                    }
                }
                await db.Plants.AddAsync(plant);
                await db.SaveChangesAsync();

                return new ResponseVM(plant);
            }
            catch (Exception)
            {
                return new ResponseVM("Error adding plant...");
            }
        }

        private void CheckTraits(Plant plant, ref bool hasNew)
        {
            List<PlantTrait> traits = [.. plant.Profile.Traits];
            var defIds = traits.Select(t => t.DefinitionId).Distinct().ToList();

            var dbTraits = db.PlantTraits.Include(pt => pt.SelectedOptions)
                                         .Where(pt => defIds.Contains(pt.DefinitionId))
                                         .ToList()
                                         .GroupBy(t => t.DefinitionId)
                                         .ToDictionary(g => g.Key, g => g.ToList());

            for (int i = 0; i < traits.Count; i++)
            {
                Normalizer.Normalize(traits[i]);

                if (dbTraits.TryGetValue(traits[i].DefinitionId, out var matches))
                {
                    var match = matches.FirstOrDefault(dbTrait => new PlantTraitComparer().Equals(dbTrait, traits[i]));

                    if (match != null)
                    {
                        traits[i] = match;
                    }
                }
                else
                {
                    hasNew = true;
                }
            }
        }
    }

    internal static class Normalizer
    {
        public static void NormalizeTraits(IEnumerable<PlantTrait> traits)
        {
            foreach (var trait in traits)
            {
                Normalize(trait);
            }
        }

        public static void Normalize(PlantTrait trait)
        {
            trait.Value = NormalizeString(trait.Value);

            foreach (var opt in trait.SelectedOptions.Where(o => !string.IsNullOrEmpty(o.Value)))
            {
                opt.Value = NormalizeString(opt.Value)!;
            }
        }

        private static string? NormalizeString(string? input)
        {
            return string.IsNullOrWhiteSpace(input) ? null : input.Trim().ToLowerInvariant();
        }
    }
}
