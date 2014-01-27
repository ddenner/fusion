using System;
using FusionSoapService.Contracts.Data;
using FusionSoapService.DataSource;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FusionSoapServiceUT
{
    [TestClass]
    public class PatientUt
    {
        [TestMethod]
        public void BasicGetPatient()
        {
            using (var patientMapper = new PatientMapper())
            {
                var patient = patientMapper.GetPatient(new Guid("C072D39B-242E-4B69-8D54-053596F54954"), 0);

                Assert.IsNotNull(patient, "Get patient should return for this key.");
                Assert.IsTrue(patient.PatientId == new Guid("C072D39B-242E-4B69-8D54-053596F54954"), "Not the correct patient id.");
            }
        }

        [TestMethod]
        public void BasicInsertPatient()
        {
            using (var patientMapper = new PatientMapper())
            {
                var patient = new Patient()
                {
                    PatientId = Guid.NewGuid(),
                    Key = 0,
                    HomeAddress = new Address()
                    {
                        Address1 = "111 Go Way",
                        Address2 = "Suite 2",
                        City = "San Jose",
                        State = "CA",
                        ZipCode = "90210",
                        GeoLocation = new SpatialData()
                        {
                            Latitude = float.Parse("21.3444"),
                            Longitude = float.Parse("32.1111")
                        }

                    },
                    HomePhone = new Phone()
                    {
                        Number = "800-800-8000"
                    },
                    PatientName = new PersonName()
                    {
                        FirstName = "FirstMyName",
                        LastName = "LastName"
                    },
                    PrimaryEmail = new EmailAddress()
                    {
                        Email = "dougfusion@ap.org"
                    }
                };

                patientMapper.InsertUpdatePatient(patient);

                var newpatient = patientMapper.GetPatient(patient.PatientId, patient.Key);

                Assert.IsNotNull(newpatient, "Get patient should return for this key.");
                Assert.IsTrue(patient.PatientId == newpatient.PatientId, "Not the correct patient id.");
            }
        }

        [TestMethod]
        public void BasicUpdatePatient()
        {
            using (var patientMapper = new PatientMapper())
            {
                var patient = new Patient()
                {
                    PatientId = Guid.NewGuid(),
                    Key = 0,
                    HomeAddress = new Address()
                    {
                        Address1 = "111 Go Way",
                        Address2 = "Suite 2",
                        City = "San Jose",
                        State = "CA",
                        ZipCode = "90210",
                        GeoLocation = new SpatialData()
                        {
                            Latitude = float.Parse("21.3444"),
                            Longitude = float.Parse("32.1111")
                        }

                    },
                    HomePhone = new Phone()
                    {
                        Number = "800-800-8000"
                    },
                    PatientName = new PersonName()
                    {
                        FirstName = "FirstMyName",
                        LastName = "LastName"
                    },
                    PrimaryEmail = new EmailAddress()
                    {
                        Email = "dougfusion@ap.org"
                    }
                };

                // initial insert
                patientMapper.InsertUpdatePatient(patient);

                // make sure new record exists
                var newpatient = patientMapper.GetPatient(patient.PatientId, patient.Key);

                Assert.IsNotNull(newpatient, "Get patient should return for this key.");
                Assert.IsTrue(patient.PatientId == newpatient.PatientId, "Not the correct patient id.");

                // update the phone #
                patient.HomePhone.Number = "900-900-9000";
                patientMapper.InsertUpdatePatient(patient);

                var updpatient = patientMapper.GetPatient(patient.PatientId, patient.Key);

                Assert.IsNotNull(updpatient, "Get patient should return for this key.");
                Assert.IsTrue(updpatient.PatientId == newpatient.PatientId, "Not the correct patient id.");
                Assert.IsTrue(patient.HomePhone.Number == updpatient.HomePhone.Number, "Phone number was not updated.");
            }
        }
    }
}
