using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.BaseClasses
{
    public abstract class BaseClass
    {
        [Key]
        public int ID { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; } = true;

        [NotMapped]
        public string? Changes { get; set; }
    }
}
