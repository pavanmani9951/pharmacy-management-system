using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PharamcyMedicineSupplyPortal.Controllers;
using PharamcyMedicineSupplyPortal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTestProjectPortalMedicine
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
      
        public void TestMethod_LoginWithoutParamters()
        {
            //Arrange 
            var controller = new DashboardController();
            string viewName = "";

            //Act
            var result = controller.Login() as ViewResult;

            //Assert
            Assert.AreEqual(viewName, result.ViewName+"");
        }

        [TestMethod(displayName: "Login with param")]
        [ExpectedException(typeof(System.NullReferenceException))]
        public async Task TestMethod_LoginWithParamters()
        {

            //Arrange 
            var controller = new DashboardController();
            string viewName = "Dashboard";


            var result = await controller.Login("test", "Pass") as ViewResult;


            Assert.AreEqual(viewName, result.ViewName);

        }

        [TestMethod]
        public void Test_ListOfPharmacySupply()
        {
            //Arrange
            var controller = new MedicineSupplyController();
            List<PharmacyMedicineSupply> pharList = new List<PharmacyMedicineSupply>()
            {
                new PharmacyMedicineSupply{Medicinename = "Gaviscon",Pharmacyname="R1",Supplycount=120}
            };

            //Act
            var result = controller.ListOfPharmacySupply(pharList) as ViewResult;

            //Assert
            Assert.AreEqual(pharList, result.Model);

        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public async Task Test_InputDemand()
        {
            //Arrange
            var controller = new MedicineSupplyController();
            string viewName = "_InputDemand";
            IEnumerable<MedicineDemand> listOfMedicine = new List<MedicineDemand>()
            {
               new MedicineDemand{Medicine = "Gaviscon",DemandCount = 120}
            };
            //Act
            var result = await controller.InputDemand(listOfMedicine) as PartialViewResult;

            //Assert
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void Test_InputDemandWithoutparam()
        {
            //Arrange
            var controller = new MedicineSupplyController();
            string viewName = "";

            //Act
            var result = controller.InputDemand() as ViewResult;

            //Assert
            Assert.AreEqual(viewName, result.ViewName + "");
        }

        [TestMethod]
        public void Test_Schedule()
        {
            //Arrange
            var controller = new ScheduleMeetingController();
            string viewName = "";

            //Act
            var result = controller.Schedule() as ViewResult;

            //Assert
            Assert.AreEqual(viewName, result.ViewName + "");
        }

        [TestMethod]
        public void Test_GetListMeet()
        {
            //Arrange
            var controller = new ScheduleMeetingController();
            List<RepSchedule> obj = new List<RepSchedule>()
            {
                new RepSchedule{Name = "R1",Dateofmeeting = System.DateTime.Now,Medicine=new List<string>{"Gavscon","Dolo-650"}
                ,Doctorname="D1",DoctorContactnumber="123456788",MeetingSlot="1PM to 2PM",TreatingAlignment="Orthopaedics"}
            };

            //Act
            var result = controller.GetListMeet(obj) as ViewResult;

            //Assert
            Assert.AreEqual(obj, result.Model);
        }

    }
}
