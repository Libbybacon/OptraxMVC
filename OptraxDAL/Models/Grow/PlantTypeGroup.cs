using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("TypeGroups", Schema = "Grow")]
    public class PlantTypeGroup
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        public string PlantType { get; set; } = string.Empty; // Fruit, Vegetable, Herb, Flower, Tree
    }
}
