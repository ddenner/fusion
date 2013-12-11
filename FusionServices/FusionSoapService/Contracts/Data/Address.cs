using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FusionSoapService.Contracts.Data
{
    /// <summary>
    /// Defines a physical location in the united states and has latitude / longitude so it can be mapped.
    /// </summary>
    /// 
    [DataContract(Namespace = @"http://dougfusion.com")]
    public class Address : AbstractData
    {
        [DataMember()]
        public string Address1 { get; set; }
        [DataMember()]
        public string Address2 { get; set; }
        [DataMember()]
        public string City { get; set; }
        [DataMember()]
        public string State { get; set; }
        [DataMember()]
        public int ZipCode { get; set; }
        [DataMember()]
        public SpatialData GeoLocation { get; set; }
    }
}
