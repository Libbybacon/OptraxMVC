using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowFlow.Models.Grow
{
    [Table("StrainRelationships", Schema = "Grow")]
    public class StrainRelationship
    {
        public StrainRelationship() { }

        public required int ParentID { get; set; }
        public Strain ParentStrain { get; set; } = null!;

        public required int ChildID { get; set; }
        public Strain ChildStrain { get; set; } = null!;
    }
}
