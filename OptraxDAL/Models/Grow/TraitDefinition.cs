﻿using Microsoft.AspNetCore.Mvc.Rendering;
using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("TraitDefinitions", Schema = "Grow")]
    public class TraitDefinition : TrackingBase
    {
        public TraitDefinition() { }

        public string Key { get; set; } = string.Empty; // e.g. "PlantingDepth"
        public string DisplayName { get; set; } = string.Empty; // e.g. "Planting Depth"
        public string? Description { get; set; }
        public string? Unit { get; set; } // e.g. inches, days, %
        public string DataType { get; set; } = "string"; // string, decimal, int, bool, etc.
        public string? Group { get; set; } // e.g. Growth, Soil, Water
        public int GroupOrder { get; set; } = 0; // Order of the group in the UI
        public int ItemOrder { get; set; } = 0; // Order of the item in the UI
        public string InputType { get; set; } = "text"; // text, number, date, checkbox, radio, select
        public bool IsDropdown { get; set; } = false;
        public bool IsMultiSelect { get; set; } = false;
        public bool IsRange { get; set; } = false;
        public bool HasUom { get; set; } = false; // Has unit of measure (e.g. inches, days, %)
        public bool AlwaysShow { get; set; } = false; // Always show this trait in the UI, even if empty
        public bool IsCustom { get; set; } = false; // User-defined trait

        public ICollection<TraitOption> Options { get; set; } = []; // Options for dropdowns or multi-selects
        public virtual ICollection<PlantTrait> Traits { get; set; } = [];

        [NotMapped]
        public ICollection<TraitOption> OrderedOpts => [.. Options.OrderBy(o => o.Category).ThenBy(o => o.Value)];

        public List<SelectListItem> GetOptionSelects()
        {
            if (Options.Count > 0)
            {
                return [.. Options.Select(o => new SelectListItem
                {
                    Value = o.Value,
                    Text = o.Value
                })];
            }
            else
            {
                return [];
            }
        }
    }
}
