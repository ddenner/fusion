using System.Runtime.Serialization;
using System.Text;
using FluentValidation.Results;

namespace FusionSoapService.Contracts.Exceptions
{
    [DataContract]
    public class FusionServicesException
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string StackTrace { get; set; }
    }
}
