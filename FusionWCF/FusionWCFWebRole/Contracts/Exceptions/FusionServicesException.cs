using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FusionServices.Contracts.Exceptions
{
    [DataContract(Namespace=@"http://dougfusion.com")]
    public class FusionServicesException
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string StackTrace { get; set; }
    }
}
