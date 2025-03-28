﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Admin;
using OptraxMVC.Areas.Grow.Models;
using OptraxMVC.Models;

namespace OptraxMVC.Services
{
    public interface ILocationService
    {
        Task<List<object>> GetLocationsAsync();
        Task<SiteLocation?> GetSiteLocationAsync();
        Task<LocationVM?> GetLocationAsync(int id);
        Task<ResponseVM> CreateAsync(LocationVM loc);
        Task<ResponseVM> EditAsync(LocationVM loc);
        Task<ResponseVM> DeleteAsync(int id);
    }

    public class LocationService(OptraxContext context, ICurrentUserService user, IMapper mapper) : ILocationService
    {
        private readonly OptraxContext db = context;
        private readonly string UserID = user.UserID;

        private readonly IMapper _mapper = mapper;

        public async Task<SiteLocation?> GetSiteLocationAsync()
        {

            return (await db.SiteLocations.Where(l => l.IsPrimary && l.UserID == UserID).Include(l => l.Address).FirstOrDefaultAsync()) ?? null;
        }

        public async Task<List<object>> GetLocationsAsync()
        {

            return [.. (await db.Locations.Where(l => l.Active && l.UserID == UserID).ToListAsync()).Select(l => l.ToTreeNode())];
        }
        public async Task<LocationVM?> GetLocationAsync(int id)
        {
            Location? dbLoc = await db.Locations.FindAsync(id);

            return (dbLoc == null || dbLoc.UserID != UserID) ? null : new LocationVM(dbLoc);
        }

        public async Task<ResponseVM> CreateAsync(LocationVM vm)
        {
            try
            {
                Location loc = vm.LocationType.ToLower() switch
                {
                    "vehicle" => new VehicleLocation(),
                    "site" => new SiteLocation() { IsPrimary = vm.IsPrimary },
                    "greenhouse" => new GreenhouseLocation(),
                    "field" => new FieldLocation(),
                    "row" => new RowLocation(),
                    "bed" => new BedLocation(),
                    "plot" => new PlotLocation(),
                    "building" => new BuildingLocation(),
                    "room" => new RoomLocation(),
                    "offsite" => new OffsiteLocation(),
                    _ => new SiteLocation()
                };
                UpdateFields(vm, loc);

                if (loc is AddressLocation addLoc && vm.Address != null)
                {
                    addLoc.AddressID = vm.AddressID;
                    addLoc.Address = vm.Address;

                    //if (addLoc.Address != null && vm.Address != null)
                    //{
                    //    _mapper.Map(vm.Address, addLoc.Address);
                    //}

                    //addLoc.BusinessID = vm.BusinessID;
                    //addLoc.Business = vm.Business;
                }

                await db.Locations.AddAsync(loc);
                await db.SaveChangesAsync();

                return new ResponseVM() { Success = true, Data = loc.ToTreeNode() };
            }
            catch (Exception)
            {
                return new ResponseVM { Msg = "Error saving new location..." };
            }
        }

        public async Task<ResponseVM> EditAsync(LocationVM vm)
        {
            try
            {
                Location? dbLoc = await db.Locations.FindAsync(vm.ID);

                if (dbLoc == null) { return new ResponseVM("Location not found"); }

                UpdateFields(vm, dbLoc);

                if (dbLoc is AddressLocation addLoc && vm.Address != null)
                {
                    if (addLoc.AddressID > 0 && vm.Address.ID == addLoc.AddressID)
                    {
                        Address? dbAdd = await db.Addresses.FindAsync(addLoc.AddressID); // update existing address

                        if (dbAdd != null)
                        {
                            _mapper.Map(vm.Address, dbAdd);
                        }
                    }
                    else if (addLoc.AddressID == null && vm.Address.ID == 0)
                    {
                        addLoc.Address = vm.Address; // creates new address
                    }
                    //addLoc.BusinessID = vm.BusinessID;
                    //addLoc.Business = vm.Business;
                }

                await db.SaveChangesAsync();

                return new ResponseVM(true);
            }
            catch (Exception ex)
            {
                return new ResponseVM("Error deleting location..." + ex.Message);
            }
        }

        private static void UpdateFields(LocationVM vm, Location loc)
        {
            loc.Name = vm.Name;
            loc.Level = vm.Level;
            loc.Details = vm.Details;
            loc.ParentID = vm.ParentID;

            loc.IconID = vm.IconID;
            loc.MapObjectID = vm.MapObjectID;
        }

        public async Task<ResponseVM> DeleteAsync(int id)
        {
            try
            {
                Location? dbLoc = await db.Locations.FindAsync(id);

                if (dbLoc == null || dbLoc.UserID != UserID)
                {
                    return new ResponseVM("Error deleting location:  Could not find location");
                }

                dbLoc.Active = false;

                await db.SaveChangesAsync();
                return new ResponseVM(true);
            }
            catch (Exception ex)
            {
                return new ResponseVM("Error deleting location..." + ex.Message);
            }
        }
    }
}
