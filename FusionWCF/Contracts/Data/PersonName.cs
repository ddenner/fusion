using System.Runtime.Serialization;

namespace FusionServices.Contracts.Data
{
    /// <summary>
    /// All of the charactertistics that define who a humanbeing
    /// </summary>
    public class PersonName : AbstractData
    {
        [DataMember()]
        public string FirstName { get; set; }
        [DataMember()]
        public string LastName { get; set; }
    }
}
