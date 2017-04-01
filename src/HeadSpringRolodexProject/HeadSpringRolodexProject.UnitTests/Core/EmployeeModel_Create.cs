using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadSpringRolodexProject.Core.Models;
using NUnit;
using NUnit.Framework;

namespace HeadSpringRolodexProject.UnitTests.Core
{
    [TestFixture]
    public class EmployeeModel_Create
    {
        [Test]
        public void EmployeeModel_Create_ShouldCreateModel()
        {
            var phoneNumberList1 = new List<PhoneNumberModel>();
            phoneNumberList1.Add(PhoneNumberModel.Create(1, PhoneNumberType.Home, "(330)234-2342"));         
            phoneNumberList1.Add(PhoneNumberModel.Create(2, PhoneNumberType.Mobile, "(440)124-2342"));
            var branchLocation = BranchLocationModel.Create(1, "Austin", "TX");

            var employee = EmployeeModel.Create(1, "John", "Smith", "Accountant", phoneNumberList1, "john.smith@aol.com", branchLocation);

            Assert.AreEqual(1, employee.EmployeeId);
            Assert.AreEqual("John", employee.FistName);
            Assert.AreEqual("Smith", employee.LastName);
            Assert.AreEqual("Accountant", employee.JobTitle);
            Assert.AreEqual(2, employee.PhoneNumbers.Count);
            Assert.AreEqual("john.smith@aol.com", employee.Email);
            Assert.AreEqual(branchLocation.State, employee.BranchLocation.State);
            Assert.AreEqual(branchLocation.City, employee.BranchLocation.City);
        }

    }
}
