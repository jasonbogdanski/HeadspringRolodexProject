using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using HeadSpringRolodexProject.Core.Models;

namespace HeadSpringRolodexProject.UnitTests.Core
{
    [TestFixture]
    public class PhoneNumberModel_Create
    {
        [Test]
        public void PhoneNumberModel_Create_ShouldCreateModel()
        {
            var phoneNumber = PhoneNumberModel.Create(1, PhoneNumberType.Home, "343-123-1232");

            Assert.AreEqual(1, phoneNumber.PhoneNumberId);
            Assert.AreEqual(PhoneNumberType.Home, phoneNumber.PhoneType);
            Assert.AreEqual("343-123-1232", phoneNumber.Number);
        }
    }
}
