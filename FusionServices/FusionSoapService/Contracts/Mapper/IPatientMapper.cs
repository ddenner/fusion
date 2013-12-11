using System;
using System.Collections.Generic;
using FusionSoapService.Contracts.Data;

namespace FusionSoapService.Contracts.Mapper
{
    public interface IPatientMapper
    {
        Patient GetPatient(Guid patientId, int region);

        List<Patient> GetPatientsWithInMiles(SpatialData location, int miles);

        List<Patient> GetPatientsByName(PersonName name);

        void InsertUpdatePatient(Patient patient);

        void DeletePatient(Guid patientId);
    }
}
