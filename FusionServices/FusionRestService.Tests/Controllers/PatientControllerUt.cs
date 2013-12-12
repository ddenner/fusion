using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using FusionRestService.Controllers;
using FusionRestService.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FusionRestService.Tests.Controllers
{
    [TestClass]
    public class PatientControllerUt
    {
        [TestMethod]
        public void BasicGetPatient()
        {
            // Arrange
            var controller = new PatientController();

            // Act
            IHttpActionResult patient = controller.GetPatient(new Guid("C072D39B-242E-4B69-8D54-053596F54954").ToString(), 0).Result;

            // Assert
            Assert.IsNotNull(patient);
            Assert.IsTrue(patient is OkNegotiatedContentResult<PatientResult>);
            Assert.IsTrue(((OkNegotiatedContentResult<PatientResult>)patient).Content.Id == new Guid("C072D39B-242E-4B69-8D54-053596F54954"));
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


            var controller = new PatientController();

            var insertedpatient = controller.AddUpdatePatient(patient).Result;

            Assert.IsNotNull(insertedpatient, "Get patient should return for this key.");
            Assert.IsTrue(insertedpatient is CreatedNegotiatedContentResult<PatientResult>);
            Assert.IsTrue(((CreatedNegotiatedContentResult<PatientResult>)insertedpatient).Content.Id == patient.Id);
        }
    }
}
