using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using FusionServices.Contracts.Data;
using FusionServices.Contracts.Service;
using FusionServices.DataSource;

namespace FusionWCFWebRole
{
    
    public class FusionService : IFusionService
    {
        public void InsertUpdatePatient(Patient patient)
        {
            using (var patientMapper = new PatientMapper())
            {
                patientMapper.InsertUpdatePatient(patient);
            }
        }

        public Patient GetPatient(Guid patientId, int region)
        {
            using (var patientMapper = new PatientMapper())
            {
                return patientMapper.GetPatient(patientId, region);
            }
        }

    }
}
