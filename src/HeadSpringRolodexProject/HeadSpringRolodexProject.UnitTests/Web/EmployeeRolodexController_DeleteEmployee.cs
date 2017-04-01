using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using HeadSpringRolodexProject.Web.Models;
using HeadSpringRolodexProject.Core.Interfaces;
using HeadSpringRolodexProject.Core.Models;
using HeadSpringRolodexProject.Web.Controllers;
using NUnit;
using NUnit.Framework;
using System.Web.Mvc;

namespace HeadSpringRolodexProject.UnitTests.Web
{
    [TestFixture]
    public class EmployeeRolodexController_DeleteEmployee
    {
        private List<BranchLocationModel> _branchLocationList { get; set; }
        private List<EmployeeModel> _employeeList { get; set; }
        private EmployeeViewModel _employeeViewModel { get; set; }

        [SetUp]
        public void Setup()
        {
            _employeeViewModel = new EmployeeViewModel
            {
                EmployeeId = 1,
                FistName = "John",
                LastName = "Smith",
                Email = "john.smith@gmai.com",
                SelectedBranchLocationId = 1,
                BranchLocationCity = "Austin",
                BranchLocationState = "TX",
                HomePhoneNumber = "(330)234-2342",
                MobilePhoneNumber = "(440)124-2342",
                JobTitle = "Engineer"

            };

            _employeeList = new List<EmployeeModel>();
            _branchLocationList = new List<BranchLocationModel>();
            var branchLocation1 = BranchLocationModel.Create(1, "Austin", "TX");
            _branchLocationList.Add(branchLocation1);
            var phoneNumberList1 = new List<PhoneNumberModel>();
            phoneNumberList1.Add(PhoneNumberModel.Create(1, PhoneNumberType.Home, "(330)234-2342"));
            phoneNumberList1.Add(PhoneNumberModel.Create(2, PhoneNumberType.Mobile, "(440)124-2342"));
            _employeeList.Add(EmployeeModel.Create(1, "John", "Smith", "Engineer", phoneNumberList1, "john.smith@gmail.com", branchLocation1));

            var branchLocation2 = BranchLocationModel.Create(2, "Wadsworth", "OH");
            _branchLocationList.Add(branchLocation2);
            var phoneNumberList2 = new List<PhoneNumberModel>();
            phoneNumberList2.Add(PhoneNumberModel.Create(3, PhoneNumberType.Home, "(234)234-1231"));
            phoneNumberList2.Add(PhoneNumberModel.Create(4, PhoneNumberType.Mobile, "(330)123-1235"));
            _employeeList.Add(EmployeeModel.Create(2, "Dudley", "Miller", "Chef", phoneNumberList2, "dudley.miller@gmail.com", branchLocation2));

            var branchLocation3 = BranchLocationModel.Create(3, "Denver", "CO");
            _branchLocationList.Add(branchLocation3);
            var phoneNumberList3 = new List<PhoneNumberModel>();
            phoneNumberList2.Add(PhoneNumberModel.Create(5, PhoneNumberType.Home, "(234)234-1231"));
            phoneNumberList2.Add(PhoneNumberModel.Create(6, PhoneNumberType.Mobile, "(330)123-1235"));
            _employeeList.Add(EmployeeModel.Create(3, "Buddy", "Holly", "Engineer", phoneNumberList3, "buddy.holly@aol.com", branchLocation3));
        }

        [TearDown]
        public void TearDown()
        {
            _employeeList = null;
            _branchLocationList = null;
            _employeeViewModel = null;
        }


        [Test]
        public void EmployeeRolodexController_DeleteConfirm_ShouldDeleteEmployeeAndReturnToIndex()
        {
            var employeeId = 1;
            var mockRolodexService = new Mock<IEmployeeModelRepository>();
            mockRolodexService.Setup(repo => repo.Remove(It.IsAny<int>()));
            mockRolodexService.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(_employeeList.FirstOrDefault(x=>x.EmployeeId == employeeId));
            mockRolodexService.Setup(repo => repo.Save());

            var mockLookUpModelService = new Mock<ILookUpModelRepository>();
            mockLookUpModelService.Setup(repo => repo.GetAllBranchLocations()).Returns(_branchLocationList);

            EmployeeRolodexController controller = new EmployeeRolodexController(mockRolodexService.Object, mockLookUpModelService.Object);

            RedirectToRouteResult result = controller.Delete(_employeeViewModel) as RedirectToRouteResult;

            mockRolodexService.Verify(x => x.Remove(employeeId), Times.AtLeastOnce());
            mockRolodexService.Verify(x => x.Save(), Times.AtLeastOnce());

            Assert.AreEqual("Index", result.RouteValues.FirstOrDefault(x => x.Key == "action").Value);
            Assert.AreEqual("EmployeeRolodex", result.RouteValues.FirstOrDefault(x => x.Key == "controller").Value);
        }

        [Test]
        public void EmployeeRolodexController_DeleteGet_ShouldReturnCorretViewModel()
        {
            var employeeId = 1;
            var mockRolodexService = new Mock<IEmployeeModelRepository>();
            mockRolodexService.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(_employeeList.FirstOrDefault(x => x.EmployeeId == employeeId));

            var mockLookUpModelService = new Mock<ILookUpModelRepository>();
            mockLookUpModelService.Setup(repo => repo.GetAllBranchLocations()).Returns(_branchLocationList);

            EmployeeRolodexController controller = new EmployeeRolodexController(mockRolodexService.Object, mockLookUpModelService.Object);

            ViewResult result = controller.Delete(employeeId) as ViewResult;

            mockLookUpModelService.Verify(x => x.GetAllBranchLocations(), Times.AtLeastOnce());
            mockRolodexService.Verify(x => x.GetById(It.IsAny<int>()), Times.AtLeastOnce());

            var model = result.Model as EmployeeViewModel;

            Assert.AreEqual(3, model.BranchLocationList.Count());

        }
    }
}