using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using HeadSpringRolodexProject.Web.Models;
using HeadSpringRolodexProject.Core.Models;


namespace HeadSpringRolodexProject.UnitTests.Web
{
    [TestFixture]
    public class EmployeeViewModel_MapFrom
    {
        [Test]
        public void EmployeeViewModel_AutoMapFromCoreModel_ShouldMap()
        {
            var phoneList = new List<PhoneNumberModel>();
            phoneList.Add(PhoneNumberModel.Create(1, PhoneNumberType.Home, "234-123-2342"));
            phoneList.Add(PhoneNumberModel.Create(2, PhoneNumberType.Mobile, "324-123-2345"));

            var branchLocation = BranchLocationModel.Create(1, "Austin", "TX");

            var employee = EmployeeModel.Create(1, "John", "Smith", "Engineer", phoneList, "john.smith@gmail.com", branchLocation);

            var employeeViewModel = EmployeeViewModel.MapFrom(employee);

            Assert.AreEqual(1, employeeViewModel.EmployeeId);
            Assert.AreEqual("John", employeeViewModel.FistName);
            Assert.AreEqual("Smith", employeeViewModel.LastName);
            Assert.AreEqual("Engineer", employeeViewModel.JobTitle);
            Assert.AreEqual("234-123-2342", employeeViewModel.HomePhoneNumber);
            Assert.AreEqual("324-123-2345", employeeViewModel.MobilePhoneNumber);
            Assert.AreEqual(1, employeeViewModel.SelectedBranchLocationId);
            Assert.AreEqual("Austin", employeeViewModel.BranchLocationCity);
            Assert.AreEqual("TX", employeeViewModel.BranchLocationState);
        }

        [Test]
        public void EmployeeViewModel_AutoMapToANewCoreModel_ShouldMap()
        {
            var employeeViewModel = new EmployeeViewModel
            {
               EmployeeId = 1,
               FistName = "John",
               LastName = "Smith",
               Email = "john.smith@gmail.com",
               SelectedBranchLocationId = 1,
               BranchLocationCity = "Austin",
               BranchLocationState = "TX",           
               HomePhoneNumber = "123-123-2342",
               MobilePhoneNumber = "234-123-5323",
               OtherPhoneNumber = "234-123-4323",
               JobTitle = "Engineer"
          
            };

            var branchLocations = new List<BranchLocationModel>();
            branchLocations.Add(new BranchLocationModel
            {
                BranchLocationId = 1,
                City = "Austin",
                State = "TX"
            });

            var employee = EmployeeViewModel.MapFrom(employeeViewModel, branchLocations);

            Assert.AreEqual(1, employee.EmployeeId);
            Assert.AreEqual("John", employee.FistName);
            Assert.AreEqual("Smith", employee.LastName);
            Assert.AreEqual("Engineer", employee.JobTitle);
            Assert.AreEqual("john.smith@gmail.com", employee.Email);
            Assert.AreEqual("Austin", employee.BranchLocation.City);
            Assert.AreEqual("TX", employee.BranchLocation.State);
            Assert.AreEqual(1, employee.BranchLocation.BranchLocationId);
            Assert.AreEqual(0, employee.PhoneNumbers.FirstOrDefault(x => x.PhoneType == PhoneNumberType.Home).PhoneNumberId);
            Assert.AreEqual("123-123-2342", employee.PhoneNumbers.FirstOrDefault(x => x.PhoneType == PhoneNumberType.Home).Number);
            Assert.AreEqual(0, employee.PhoneNumbers.FirstOrDefault(x => x.PhoneType == PhoneNumberType.Mobile).PhoneNumberId);
            Assert.AreEqual("234-123-5323", employee.PhoneNumbers.FirstOrDefault(x => x.PhoneType == PhoneNumberType.Mobile).Number);
            Assert.AreEqual(0, employee.PhoneNumbers.FirstOrDefault(x => x.PhoneType == PhoneNumberType.Other).PhoneNumberId);
            Assert.AreEqual("234-123-4323", employee.PhoneNumbers.FirstOrDefault(x => x.PhoneType == PhoneNumberType.Other).Number);
            
        }

        [Test]
        public void EmployeeViewModel_AutoMapToAnExistingCoreModel_ShouldMap()
        {
            var phoneList = new List<PhoneNumberModel>();
            phoneList.Add(PhoneNumberModel.Create(1, PhoneNumberType.Home, "234-123-2342"));
            phoneList.Add(PhoneNumberModel.Create(2, PhoneNumberType.Mobile, "324-123-2345"));

            var branchLocation = BranchLocationModel.Create(1, "Austin", "TX");

            var existingEmployee = EmployeeModel.Create(1, "John", "Smith", "Engineer", phoneList, "john.smith@gmail.com", branchLocation);

            var employeeViewModel = new EmployeeViewModel
            {
                EmployeeId = 1,
                FistName = "Bud",
                LastName = "Miller",
                Email = "bud.miller@gmail.com",
                SelectedBranchLocationId = 2,
                BranchLocationCity = "Wadsworth",
                BranchLocationState = "OH",
                HomePhoneNumber = "123-123-2342",
                MobilePhoneNumber = "",
                OtherPhoneNumber = "",
                JobTitle = "Cook"

            };

            var branchLocations = new List<BranchLocationModel>();
            branchLocations.Add(new BranchLocationModel
            {
                BranchLocationId = 1,
                City = "Austin",
                State = "TX"
            });
            branchLocations.Add(new BranchLocationModel
            {
                BranchLocationId = 2,
                City = "Wadsworth",
                State = "OH"
            });

            var employee = EmployeeViewModel.MapFrom(employeeViewModel, existingEmployee, branchLocations);

            Assert.AreEqual(1, employee.EmployeeId);
            Assert.AreEqual("Bud", employee.FistName);
            Assert.AreEqual("Miller", employee.LastName);
            Assert.AreEqual("Cook", employee.JobTitle);
            Assert.AreEqual("bud.miller@gmail.com", employee.Email);
            Assert.AreEqual("Wadsworth", employee.BranchLocation.City);
            Assert.AreEqual("OH", employee.BranchLocation.State);
            Assert.AreEqual(2, employee.BranchLocation.BranchLocationId);
            Assert.AreEqual("123-123-2342", employee.PhoneNumbers.FirstOrDefault(x => x.PhoneType == PhoneNumberType.Home).Number);
            Assert.IsNull(employee.PhoneNumbers.FirstOrDefault(x => x.PhoneType == PhoneNumberType.Mobile));
            Assert.IsNull(employee.PhoneNumbers.FirstOrDefault(x => x.PhoneType == PhoneNumberType.Other));
        }

    }
}
