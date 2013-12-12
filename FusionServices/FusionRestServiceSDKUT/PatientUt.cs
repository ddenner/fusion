using System;
using FusionRestServiceSDK.Data;
using FusionRestServiceSDK.Mapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FusionRestServiceSDKUT
{
    [TestClass]
    public class PatientUt
    {
        [TestMethod]
        public void BasicGetPatient()
        {
            // Arrange
            var patientMapper = new PatientMapper();

            // Act
            PatientResult patient = patientMapper.GetById(new Guid("C072D39B-242E-4B69-8D54-053596F54954"), 0);

            // Assert
            Assert.IsNotNull(patient);
            Assert.IsTrue(patient.Id == new Guid("C072D39B-242E-4B69-8D54-053596F54954"));
        }

        [TestMethod]
        public void BasicInsertPatient()
        {
            var patient = new Patient()
            {
                Id = Guid.NewGuid(),
                Region = 0,
                Address1 = "4120 Dover Road",
                Address2 = "Suite 1",
                City = "La Canada",
                State = "CA",
                ZipCode = "91011",
                Phone = "800-800-8000",
                FirstName = "FirstMyName",
                LastName = "LastName",
                Email = "dougfusion@gmail.com"
            };


            var patientMapper = new PatientMapper();

            var insertedpatient = patientMapper.AddOrUpdate(patient);

            Assert.IsNotNull(insertedpatient, "Get patient should return for this key.");
            Assert.IsTrue(insertedpatient.Id == patient.Id);
        }
    }
}
