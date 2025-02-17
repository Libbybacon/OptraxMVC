using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    public class Strain
    {
        public Strain()
        {
            Plants = [];
        }
        
        public int ID { get; set; }
       
        public required string Name { get; set; }

        public int? OriginCompanyID { get; set; }

        public string? GeneticOrigin { get; set; }

        public string? Description { get; set; }
       
        public required string StrainType { get; set; }

        public required bool Active { get; set; } = true;

        public virtual ICollection<Plant> Plants { get; set; }
        public virtual ICollection<StrainRelationship>? Parents { get; set; }
        public virtual ICollection<StrainRelationship>? Children { get; set; }
    }

    public class StrainRelationship
    {
        public StrainRelationship() { }

        public int ParentID { get; set; }
        public int ChildID { get; set; }

        public Strain ParentStrain { get; set; } = null!;
        public Strain ChildStrain { get; set; } = null!;
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
