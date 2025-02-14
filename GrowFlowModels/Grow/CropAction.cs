using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowFlow.Models
{
    public class CropAction
    {
        public CropAction() { }

        public int ID { get; set; }

        [ForeignKey("Crop")]
        public int CropID { get; set; }

        public DateTimeOffset Date { get; set; }

        public required string Action { get; set; }

        public string? Notes { get; set; }

        public bool? AllPlants { get; set; }

        public string? PlantIDs { get; set; }

        public required virtual Crop Crop { get; set; }



    }
}
