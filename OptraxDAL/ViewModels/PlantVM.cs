namespace OptraxDAL.ViewModels
{
    public class PlantVM
    {
        public int PlantId { get; set; }
        public string? CropId { get; set; }
        public int StrainId { get; set; }
        public string TrackingId { get; set; } = string.Empty;
        public string? Strain { get; set; } = string.Empty;
        public bool IsMother { get; set; } = false;
        public string? MotherName { get; set; }
        public string PropagationType { get; set; } = string.Empty;
        public string Phase { get; set; } = string.Empty;
        public string? CurrentPhase { get; set; }
        public string? LocationName { get; set; }
        public string? LocationType { get; set; }
        public int? Quantity { get; set; } = 1;
    }
}
