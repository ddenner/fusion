using System.Runtime.Serialization;

namespace FusionSoapService.Contracts.Data
{
    /// <summary>
    /// All of the charactertistics that define who a humanbeing
    /// </summary>
    [DataContract(Namespace = @"http://dougfusion.com")]
    public class PersonName : AbstractData
    {
        [DataMember()]
        public string FirstName { get; set; }
        [DataMember()]
        public string LastName { get; set; }
    }
}
