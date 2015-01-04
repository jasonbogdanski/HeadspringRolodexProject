using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadSpringRolodexProject.Core.Model;
using NUnit;
using NUnit.Framework;

namespace HeadSpringRolodexProject.UnitTests.Core
{
    [TestFixture]
    public class EmployeeModel_CreateModel
    {
        [Test]
        public void EmployeeModel_Create_CanCreateModel()
        {
            var phoneNumberList1 = new List<PhoneNumberModel>();
            phoneNumberList1.Add(new PhoneNumberModel
            {
                Number = "(330)234-2342",
                PhoneType = PhoneNumberType.Home
            });
            phoneNumberList1.Add(new PhoneNumberModel
            {
                Number = "(440)124-2342",
                PhoneType = PhoneNumberType.Mobile
            });

            var employee = EmployeeModel.Create(1, "John", "Smith", "Accountant", phoneNumberList1, "john.smith@aol.com", "Austin, TX");

            Assert.AreEqual(1, employee.Id);
            Assert.AreEqual("John", employee.FistName);
            Assert.AreEqual("Smith", employee.LastName);
            Assert.AreEqual("Accountant", employee.JobTitle);
            Assert.AreEqual(2, employee.PhoneNumbers.Count);
            Assert.AreEqual("john.smith@aol.com", employee.Email);
            Assert.AreEqual("Austin, TX", employee.Location);
        }

    }
}
