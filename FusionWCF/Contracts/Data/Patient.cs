using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FusionServices.Contracts.Data
{
    /// <summary>
    /// Defines the data that makes up a customer who is receiving medical services
    /// </summary>
    [DataContract(Namespace = @"http://dougfusion.com")]
    public class Patient : AbstractData, IFederatedKey
    {
        // unique identifier
        [DataMember()]
        public Guid PatientId { get; set; }
        // human identifier
        [DataMember()]
        public PersonName PatientName { get; set; }
        // communication account
        [DataMember()]
        public EmailAddress PrimaryEmail { get; set; }
        [DataMember()]
        public Phone HomePhone { get; set; }
        // physical location for residence
        [DataMember()]
        public Address HomeAddress { get; set; }
        [DataMember()]
        // change history
        public ChangeInformation Tracking { get; set; }
        // partition key
        [DataMember()]
        public int Key { get; set; }
    }
}
