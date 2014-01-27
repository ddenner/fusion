using System;
using System.ServiceModel;
using FusionSoapService.Contracts.Data;
using FusionSoapService.Contracts.Exceptions;

namespace FusionSoapService
{
    /// <summary>
    /// Defines all of the actions taken on a patient/practice/doctor
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
