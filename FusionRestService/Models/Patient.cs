using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FusionSoapServiceSDK.FusionSoapService;

namespace FusionRestService.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public int Region { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public Patient()
        {
        }

        public FusionSoapServiceSDK.FusionSoapService.Patient ToSoapPatient()
        {
            var patient = new FusionSoapServiceSDK.FusionSoapService.Patient()
            {
                PatientId = Id,
                Key = Region,
                PatientName = new PersonName()
                {
                    FirstName = FirstName,
                    LastName = LastName
                },
                PrimaryEmail = new EmailAddress()
                {
                    Email = Email
                },
                HomePhone = new Phone()
                {
                    Number = Phone
                },
                HomeAddress = new Address()
                {
                    Address1 = Address1,
                    Address2 = Address2,
                    City = City,
                    State = State,
                    ZipCode = ZipCode
                }
            };

            return patient;
        }

        internal Patient(FusionSoapServiceSDK.FusionSoapService.Patient patient)
        {
            Id = patient.PatientId;
            Region = patient.Key;

            if (null != patient.PatientName)
            {
                FirstName = patient.PatientName.FirstName;
                LastName = patient.PatientName.LastName;
            }

            if (null != patient.PrimaryEmail)
            {
                Email = patient.PrimaryEmail.Email;
            }

            if (null != patient.HomePhone)
            {
                Phone = patient.HomePhone.Number;
            }

            if (null != patient.HomeAddress)
            {
                Address1 = patient.HomeAddress.Address1;
                Address2 = patient.HomeAddress.Address2;
                City = patient.HomeAddress.City;
                State = patient.HomeAddress.State;
                ZipCode = patient.HomeAddress.ZipCode;
            }
        }
    }
}