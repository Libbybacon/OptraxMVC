using OptraxDAL.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace OptraxDAL.Models.Admin
{
    public class Building
    {
        public Building() { }

        public int ID { get; set; }

        public int LocationID { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public int AddressID { get; set; }


        public required virtual Address Address { get; set; }

        public required virtual BuildingLocation Location { get; set; }
    }
}
