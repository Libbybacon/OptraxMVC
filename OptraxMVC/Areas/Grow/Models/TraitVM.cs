using OptraxDAL.Models.Grow;

namespace OptraxMVC.Areas.Grow.Models
{
    public class TraitVM
    {
        public string DefinitionId { get; set; } = null!;
        public string DefKey { get; set; } = null!; // e.g. "PlantingDepth"
        public string DisplayName { get; set; } = string.Empty; // e.g. "Planting Depth"
        public string? Description { get; set; }
        public string? Unit { get; set; }
        public string DataType { get; set; } = "string";
        public string? Group { get; set; } // e.g. Growth, Soil, Water
        public bool IsDropdown { get; set; } = false;
        public bool IsMultiSelect { get; set; } = false;
        public bool IsRange { get; set; } = false;
        public bool AlwaysShow { get; set; } = false;
        public bool IsCustom { get; set; } = false;

        public string? Value { get; set; } // for text, single dropdown
        public List<string> SelectedOptions { get; set; } = [];
        public List<TraitOption>? Options { get; set; }
    }
}
