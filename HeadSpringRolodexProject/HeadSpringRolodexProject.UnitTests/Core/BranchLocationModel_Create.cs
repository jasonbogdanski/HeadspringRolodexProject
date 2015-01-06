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
    public class BranchLocationModel_Create
    {
        [Test]
        public void BranchLocationModel_Create_ShouldCreateModel()
        {
            var branchLocation = BranchLocationModel.Create(1, "Austin", "TX");

            Assert.AreEqual(1, branchLocation.BranchLocationId);
            Assert.AreEqual("Austin", branchLocation.City);
            Assert.AreEqual("TX", branchLocation.State);
        }

    }
}
