using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FusionSoapServiceSDK.FusionSoapService;

namespace FusionSoapServiceSDKUT
{
    [TestClass]
    public class PatientUt
    {
        [TestMethod]
        public void BasicGetPatient()
        {
            using (var client = new FusionServiceClient())
            {
                var patient = client.GetPatient(new Guid("C072D39B-242E-4B69-8D54-053596F54954"), 0);

                Assert.IsNotNull(patient, "Get patient should return for this key.");
                Assert.IsTrue(patient.PatientId == new Guid("C072D39B-242E-4B69-8D54-053596F54954"), "Not the correct patient id.");
            }
        }

        [TestMethod]
        public void BasicInsertPatient()
        {
            using (var client = new FusionServiceClient())
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

                client.InsertUpdatePatient(patient);

                var newpatient = client.GetPatient(patient.PatientId, patient.Key);

                Assert.IsNotNull(newpatient, "Get patient should return for this key.");
                Assert.IsTrue(patient.PatientId == newpatient.PatientId, "Not the correct patient id.");
            }
        }

        [TestMethod]
        public void BasicUpdatePatient()
        {
            using (var client = new FusionServiceClient())
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
                client.InsertUpdatePatient(patient);

                // make sure new record exists
                var newpatient = client.GetPatient(patient.PatientId, patient.Key);

                Assert.IsNotNull(newpatient, "Get patient should return for this key.");
                Assert.IsTrue(patient.PatientId == newpatient.PatientId, "Not the correct patient id.");

                // update the phone #
                patient.HomePhone.Number = "900-900-9000";
                client.InsertUpdatePatient(patient);

                var updpatient = client.GetPatient(patient.PatientId, patient.Key);

                Assert.IsNotNull(updpatient, "Get patient should return for this key.");
                Assert.IsTrue(updpatient.PatientId == newpatient.PatientId, "Not the correct patient id.");
                Assert.IsTrue(patient.HomePhone.Number == updpatient.HomePhone.Number, "Phone number was not updated.");
            }
        }
    }
}
