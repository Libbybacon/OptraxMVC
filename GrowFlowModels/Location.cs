using GrowFlow.Models.Grow;

namespace GrowFlow.Models
{
    public class Location
    {
        public Location()
        {
            Active = true;
        }

        public required int ID { get; set; }
        public string? LocationType { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }

        public required bool Active { get; set; }

        public List<Room>? Rooms { get; set; }
    }
}
