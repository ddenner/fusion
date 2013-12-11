using System.Runtime.Serialization;

namespace FusionSoapService.Contracts.Data
{
    /// <summary>
    /// Defines the store for a special string type that should be a valid email address
    /// </summary>
    [DataContract(Namespace = @"http://dougfusion.com")]
    public class Phone : AbstractData
    {
        [DataMember()]
        public string Number { get; set; }
    }
}
