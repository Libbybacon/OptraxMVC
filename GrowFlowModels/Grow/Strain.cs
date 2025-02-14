using GrowFlow.Models.Crops;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrowFlow.Models
{
    [Table("Strains", Schema = "Grow")]
    public class Strain
    {
        public Strain()
        {
            Plants = [];
        }
        
        public int ID { get; set; }
       
        public required string Name { get; set; }

        public string? Description { get; set; }
       
        public required string StrainType { get; set; }

        public virtual ICollection<Plant> Plants { get; set; }
        public virtual ICollection<StrainRelationship>? Parents { get; set; }
        public virtual ICollection<StrainRelationship>? Children { get; set; }
    }


    [Table("StrainRelationships", Schema = "Grow")]
    public class StrainRelationship
    {
        public StrainRelationship() { }

        public int ParentID { get; set; }
        public int ChildID { get; set; }

        public Strain ParentStrain { get; set; } = null!;
        public Strain ChildStrain { get; set; } = null!;
    }
}
