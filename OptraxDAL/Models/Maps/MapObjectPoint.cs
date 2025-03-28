using ProtoBuf;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace OptraxDAL.Models.Maps
{
    [Table("MapObjectPoints", Schema = "Map")]
    public class MapObjectPoint
    {
        public MapObjectPoint() { }

        [DataMember]
        [ProtoMember(1)]
        public int ID { get; set; }

        [DataMember]
        [ProtoMember(2)]
        public int MapObjectID { get; set; }

        [DataMember]
        [ProtoMember(3)]
        public decimal Latitude { get; set; }

        [DataMember]
        [ProtoMember(4)]
        public decimal Longitude { get; set; }

        [DataMember]
        [ProtoMember(5)]
        public decimal? Elevation { get; set; }
    }
}
