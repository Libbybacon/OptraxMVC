namespace OptraxDAL.Models.Grow
{
    public class Strain
    {
        public Strain() { }

        public int ID { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string StrainType { get; set; }
        public int? Generation { get; set; }
        public int? OriginID { get; set; }
        public string? OriginType { get; set; }
        public required bool Active { get; set; } = true;

        public virtual ICollection<Crop> Crops { get; set; } = [];
        public virtual ICollection<StrainRelationship> Parents { get; set; } = [];
        public virtual ICollection<StrainRelationship> Children { get; set; } = [];
    }

    public class StrainRelationship
    {
        public StrainRelationship() { }

        public int ChildID { get; set; }
        public int ParentID { get; set; }

        public Strain ChildStrain { get; set; } = null!;
        public Strain ParentStrain { get; set; } = null!;
    }

    public enum StrainTypes
    {
        Indica,
        Sativa,
        Hybrid
    }

    public enum OriginTypes
    {
        InHouse,
        External
    }
}
