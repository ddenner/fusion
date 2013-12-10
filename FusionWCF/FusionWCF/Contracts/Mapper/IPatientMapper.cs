using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FusionServices.Contracts.Data;

namespace FusionServices.Contracts.Mapper
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
