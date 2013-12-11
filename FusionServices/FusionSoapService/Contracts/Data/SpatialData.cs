using System.Runtime.Serialization;

namespace FusionSoapService.Contracts.Data
{
    /// <summary>
    /// To allow for geo querying
    /// </summary>
    [DataContract]
    public class SpatialData : AbstractData
    {
        [DataMember()]
        public float Latitude { get; set; }
        [DataMember()]
        public float Longitude { get; set; }
    }
}
