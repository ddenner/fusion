using System;
using System.Runtime.Serialization;

namespace FusionSoapService.Contracts.Data
{
    /// <summary>
    /// Stores any data that tracks changes/updates of the data
    /// </summary>
    /// 
    [DataContract(Namespace = @"http://dougfusion.com")]
    public class ChangeInformation : AbstractData
    {
        [DataMember()]
        public DateTime InsertDate { get; set; }
        [DataMember()]
        public DateTime ModifiedDate { get; set; }
    }
}
