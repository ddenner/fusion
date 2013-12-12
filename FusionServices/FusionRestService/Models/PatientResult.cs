using System;

namespace FusionRestService.Models
{
    public class PatientResult : Patient
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public PatientResult()
        {
        }

        internal PatientResult(FusionSoapServiceSDK.FusionSoapService.Patient patient) : base(patient)
        {
            if ((null != patient.HomeAddress) && (null != patient.HomeAddress.GeoLocation))
            {
                Latitude = patient.HomeAddress.GeoLocation.Latitude;
                Longitude = patient.HomeAddress.GeoLocation.Longitude;
            }

            if (null != patient.Tracking)
            {
                InsertDate = patient.Tracking.InsertDate;
                ModifiedDate = patient.Tracking.ModifiedDate;
            }
        }
    }
}