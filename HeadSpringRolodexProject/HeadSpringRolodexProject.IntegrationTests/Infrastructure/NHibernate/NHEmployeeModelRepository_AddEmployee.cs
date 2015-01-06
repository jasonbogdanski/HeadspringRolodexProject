using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadSpringRolodexProject.DataAccessLayer;
using NUnit;
using NUnit.Framework;
using HeadSpringRolodexProject.Core.Models;
using HeadSpringRolodexProject.DataAccessLayer.NHibernate;

namespace HeadSpringRolodexProject.IntegrationTests.DataAccessLayer.NHibernate
{
    [TestFixture]
    public class NHEmployeeModelRepository_AddEmployee: NHibernateFixtureBase
    {
        public NHEmployeeModelRepository_AddEmployee() : base(typeof(HeadSpringRolodexProject.DataAccessLayer.NHibernate.Mappings.EmployeeModelMapping).Assembly) { }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            this.Dispose();
        }

        [Test]
        [Ignore]
        //Ignore for now until repository tests can run against in memory database.
        public void AddEmployee_AddOneEmployee_SavesCorrectly()
        {
            var employeeRepo = new NHEmployeeModelRepository(SessionFactory);
            var employeeModel = new EmployeeModel
            {
                FistName = "John",
                LastName = "Smith",
                JobTitle = "Engineer",
                Email = "John.Smith@gmail.com"
            };

            employeeRepo.Add(employeeModel);
        }
    }
}
