using System.Runtime.Serialization;

namespace FusionServices.Contracts.Data
{
    public class SpatialData : AbstractData
    {
        [DataMember()]
        public float Latitude { get; set; }
        [DataMember()]
        public float Longitude { get; set; }
    }
}
