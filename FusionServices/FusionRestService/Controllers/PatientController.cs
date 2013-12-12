using System;
using System.Threading.Tasks;
using System.Web.Http;
using FusionRestService.Mapper;
using FusionRestService.Models;
using FusionSoapServiceSDK.FusionSoapService;

namespace FusionRestService.Controllers
{
    public class PatientController : ApiController
    {
        //  api/patient/
        [HttpGet]
        [ActionName("GetPatient")]
        public async Task<IHttpActionResult> GetPatient(string patientId, int region)
        {
            using (var patientSvc = new FusionServiceClient())
            {
                var patient = await patientSvc.GetPatientAsync(new Guid(patientId), region);

                if (null == patient)
                    return NotFound();

                return Ok(new PatientResult(patient));
            }
        }

        [HttpPost]
        [ActionName("AddUpdatePatient")]
        public async Task<IHttpActionResult> AddUpdatePatient(FusionRestService.Models.Patient patient)
        {
            var googleGeocoding = new GeographyMapper();

            // TODO move this to async function to not tie up thread
            var googleGeocodeResponse = googleGeocoding.Geocode(string.Format("{0},{1},{2}", patient.Address1, patient.City, patient.State));

            using (var patientSvc = new FusionServiceClient())
            {
                var soapPatient = patient.ToSoapPatient();
                // apply the geo tag if we got any
                if (null != googleGeocodeResponse &&
                    null != googleGeocodeResponse.results &&
                    googleGeocodeResponse.results.Count > 0 &&
                    null != googleGeocodeResponse.results[0].geometry &&
                    null != googleGeocodeResponse.results[0].geometry.location)
                {
                    soapPatient.HomeAddress.GeoLocation = new SpatialData()
                    {
                        Latitude = googleGeocodeResponse.results[0].geometry.location.lat,
                        Longitude = googleGeocodeResponse.results[0].geometry.location.lng
                    };
                }
                    
                await patientSvc.InsertUpdatePatientAsync(soapPatient);

                return Created("http://fusionrestservice.cloudapp.net/api/patient", new PatientResult(soapPatient));
            }
        }
    }
}
