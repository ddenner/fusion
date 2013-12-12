using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FusionRestServiceSDK.Data;
using System.Net.Http;

namespace FusionRestServiceSDK.Mapper
{
    public class PatientMapper : AbstractMapper
    {
        public PatientResult AddOrUpdate(Patient patient)
        {
            var response = HttpPost("http://fusionrestservice.cloudapp.net/api/patient/addpatient/", patient.ToString());
            if (null != response)
                return PatientResult.Parse(response);
            else return null;
        }

        public PatientResult GetById(Guid id, int region)
        {
            var response = HttpGet(string.Format("http://fusionrestservice.cloudapp.net/api/patient/getpatient/{0}/{1}", id.ToString(), region));
            if (null != response)
                return PatientResult.Parse(response);
            else return null;
        }
    }
}
