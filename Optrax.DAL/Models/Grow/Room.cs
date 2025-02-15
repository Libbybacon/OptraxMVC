using OptraxDAL.Models.Inventory;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    public class Room
    {
        public Room()
        {
            Active = true;
            Plants = [];
            TransfersIn = [];
            TransfersOut = [];
        }

        public int ID { get; set; }

        [MaxLength(50)]
        public required string Name { get; set; }        
        
        [MaxLength(250)]
        public string? Description { get; set; }
        
        public int? LocationID { get; set; }
        public bool Active { get; set; }

        public virtual InventoryLocation? Location { get; set; }

        public virtual ICollection<Plant> Plants { get; set; }

        [InverseProperty(nameof(RoomTransfer.ToRoom))]
        public virtual ICollection<RoomTransfer> TransfersIn { get; set; }

        [InverseProperty(nameof(RoomTransfer.FromRoom))]
        public virtual ICollection<RoomTransfer> TransfersOut { get; set; }
    }
}
