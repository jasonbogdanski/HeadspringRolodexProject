using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using HeadSpringRolodexProject.Core.Interfaces;
using HeadSpringRolodexProject.Core.Models;
using HeadSpringRolodexProject.Core.Services;
using Moq;


namespace HeadSpringRolodexProject.UnitTests.Core
{
    [TestFixture]
    public class EmployeeRolodexService_GetEmployeesBySearchString
    {
        [Test]
        public void GetEmployeesBySearchString_SearchReturnsNoResults_ReturnsNoResults()
        {
            var mock = new Mock<IEmployeeModelRepository>();
            mock.Setup(repo => repo.GetEmployeesBySearchString("John")).Returns(new List<EmployeeModel>());

            var employeeRolodexService = new EmployeeRolodexService(mock.Object);

            Assert.AreEqual(0, employeeRolodexService.GetEmployeesBySearchString("John").Count);

            mock.Verify(repo => repo.GetEmployeesBySearchString("John"), Times.AtLeastOnce());

        }

        [Test]
        public void GetEmployeesBySearchString_SearchReturnsResults_ReturnsCorrectNumberOfResults()
        {
            var mock = new Mock<IEmployeeModelRepository>();
            var employeeList = new List<EmployeeModel>();
            employeeList.Add(new EmployeeModel
            {
                FistName = "John",
                LastName = "Smith"
            });
            employeeList.Add(new EmployeeModel
            {
                FistName = "Nancy",
                LastName = "Smith"
            });
            mock.Setup(repo => repo.GetEmployeesBySearchString("Smith")).Returns(employeeList);

            var employeeRolodexService = new EmployeeRolodexService(mock.Object);

            Assert.AreEqual(2, employeeRolodexService.GetEmployeesBySearchString("Smith").Count);

            mock.Verify(repo => repo.GetEmployeesBySearchString("Smith"), Times.AtLeastOnce());

        }

        [Test]
        public void GetEmployeesBySearchString_NullOrEmptySearchString_ReturnsNoResults()
        {
            var mock = new Mock<IEmployeeModelRepository>();
            var employeeList = new List<EmployeeModel>();
            employeeList.Add(new EmployeeModel
            {
                FistName = "John",
                LastName = "Smith"
            });
            employeeList.Add(new EmployeeModel
            {
                FistName = "Nancy",
                LastName = "Smith"
            });
            mock.Setup(repo => repo.GetEmployeesBySearchString("Smith")).Returns(employeeList);

            var employeeRolodexService = new EmployeeRolodexService(mock.Object);

            Assert.AreEqual(0, employeeRolodexService.GetEmployeesBySearchString(null).Count);

            mock.Verify(repo => repo.GetEmployeesBySearchString(null), Times.Never());

            mock.ResetCalls();

            Assert.AreEqual(0, employeeRolodexService.GetEmployeesBySearchString("").Count);

            mock.Verify(repo => repo.GetEmployeesBySearchString(null), Times.Never());

        }

    }
}
