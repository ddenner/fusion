using System.Runtime.Serialization;

namespace FusionSoapService.Contracts.Data
{
    /// <summary>
    /// Defines the store for a special string type that should be a valid email address
    /// </summary>
    public class EmailAddress : AbstractData
    {
        [DataMember()]
        public string Email { get; set; }
    }
}
