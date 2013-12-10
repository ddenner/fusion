using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using FusionServices.Contracts.Data;
using FusionServices.Contracts.Exceptions;

namespace FusionServices.Contracts.Service
{
    /// <summary>
    /// Main service entry point for all actions performed
    /// </summary>
    [ServiceContract(Namespace = @"http://dougfusion.com")]
    public interface IFusionService
    {
        [OperationContract]
        [FaultContract(typeof(FusionServicesException))]
        void InsertUpdatePatient(Patient patient);

        [OperationContract]
        [FaultContract(typeof(FusionServicesException))]
        Patient GetPatient(Guid patientId, int region);
    }
}
