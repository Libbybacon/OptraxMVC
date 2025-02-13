using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrowFlow.Models.Grow
{
    [Table("Strains", Schema = "Grow")]
    public class Strain
    {
        public Strain()
        {
            Plants = [];
        }
        
        public required int ID { get; set; }
       
        public required string Name { get; set; }

        public string? Description { get; set; }
       
        public required string StrainType { get; set; }

        public virtual ICollection<Plant> Plants { get; set; }
        public virtual ICollection<StrainRelationship>? Parents { get; set; }
        public virtual ICollection<StrainRelationship>? Children { get; set; }
    }
}
