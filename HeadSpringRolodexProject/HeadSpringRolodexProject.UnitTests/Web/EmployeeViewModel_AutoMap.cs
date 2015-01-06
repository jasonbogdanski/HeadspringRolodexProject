using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using AutoMapper;
using HeadSpringRolodexProject.Web.Models;
using HeadSpringRolodexProject.Core.Models;


namespace HeadSpringRolodexProject.UnitTests.Web
{
    [TestFixture]
    public class EmployeeViewModel_AutoMap
    {
        [Test]
        public void EmployeeViewModel_AutoMapFromCoreModel_ShouldMap()
        {
            var phoneList = new List<PhoneNumberModel>();
            phoneList.Add(PhoneNumberModel.Create(1, PhoneNumberType.Home, "234-123-2342"));
            phoneList.Add(PhoneNumberModel.Create(2, PhoneNumberType.Mobile, "324-123-2345"));

            var branchLocation = BranchLocationModel.Create(1, "Austin", "TX");

            var employee = EmployeeModel.Create(1, "John", "Smith", "Engineer", phoneList, "john.smith@gmail.com", branchLocation);

            Mapper.CreateMap<BranchLocationModel, BranchLocationViewModel>();
            Mapper.CreateMap<PhoneNumberModel, PhoneNumberViewModel>();

            var employeeViewModel = new EmployeeViewModel();
            employeeViewModel.CreateMappings(Mapper.Configuration);

            employeeViewModel = Mapper.Map<EmployeeViewModel>(employee);

            Assert.AreEqual(1, employeeViewModel.EmployeeId);
            Assert.AreEqual("John", employeeViewModel.FistName);
            Assert.AreEqual("Smith", employeeViewModel.LastName);
            Assert.AreEqual("Engineer", employeeViewModel.JobTitle);
            Assert.AreEqual(1, employeeViewModel.HomePhoneNumber.PhoneNumberId);
            Assert.AreEqual("234-123-2342", employeeViewModel.HomePhoneNumber.Number);
            Assert.AreEqual(2, employeeViewModel.MobilePhoneNumber.PhoneNumberId);
            Assert.AreEqual("324-123-2345", employeeViewModel.MobilePhoneNumber.Number);
        }

        [Test]
        public void EmployeeViewModel_AutoMapToCoreModel_ShouldMap()
        {

            var employeeViewModel = new EmployeeViewModel
            {
               EmployeeId = 1,
               FistName = "John",
               LastName = "Smith",
               Email = "john.smith@gmail.com",
               BranchLocation = new BranchLocationViewModel
               {
                   BranchLocationId = 1,
                   City = "Austin",
                   State = "TX"
               },
               HomePhoneNumber = new PhoneNumberViewModel
               {
                   PhoneNumberId = 1,
                   Number = "123-123-2342"
               },
               MobilePhoneNumber = new PhoneNumberViewModel
               {
                   PhoneNumberId = 2,
                   Number = "234-123-5323"
               },
               OtherPhoneNumber = new PhoneNumberViewModel
               {
                   PhoneNumberId = 3,
                   Number = "234-123-4323"
               },
               JobTitle = "Engineer"
          
            };

            Mapper.CreateMap<BranchLocationViewModel, BranchLocationModel>();
            Mapper.CreateMap<PhoneNumberViewModel, PhoneNumberModel>();
            employeeViewModel.CreateMappings(Mapper.Configuration);

            var employee = Mapper.Map<EmployeeModel>(employeeViewModel);

            Assert.AreEqual(1, employee.EmployeeId);
            Assert.AreEqual("John", employee.FistName);
            Assert.AreEqual("Smith", employee.LastName);
            Assert.AreEqual("Engineer", employee.JobTitle);
            Assert.AreEqual("john.smith@gmail.com", employee.Email);
            Assert.AreEqual("Austin", employee.BranchLocation.City);
            Assert.AreEqual("TX", employee.BranchLocation.State);
            Assert.AreEqual(1, employee.BranchLocation.BranchLocationId);
            Assert.AreEqual(1, employee.PhoneNumbers.FirstOrDefault(x => x.PhoneType == PhoneNumberType.Home).PhoneNumberId);
            Assert.AreEqual("123-123-2342", employee.PhoneNumbers.FirstOrDefault(x => x.PhoneType == PhoneNumberType.Home).Number);
            Assert.AreEqual(2, employee.PhoneNumbers.FirstOrDefault(x => x.PhoneType == PhoneNumberType.Mobile).PhoneNumberId);
            Assert.AreEqual("234-123-5323", employee.PhoneNumbers.FirstOrDefault(x => x.PhoneType == PhoneNumberType.Mobile).Number);
            Assert.AreEqual(3, employee.PhoneNumbers.FirstOrDefault(x => x.PhoneType == PhoneNumberType.Other).PhoneNumberId);
            Assert.AreEqual("234-123-4323", employee.PhoneNumbers.FirstOrDefault(x => x.PhoneType == PhoneNumberType.Other).Number);
            
        }

    }
}
