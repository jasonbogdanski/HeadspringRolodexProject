using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadSpringRolodexProject.Infrastructure;
using NUnit;
using NUnit.Framework;
using HeadSpringRolodexProject.Core.Model;


using HeadSpringRolodexProject.Infrastructure.NHibernate;namespace HeadSpringRolodexProject.IntegrationTests.Infrastructure.NHibernate
{
    [TestFixture]
    public class NHEmployeeModelRepository_AddEmployee: NHibernateFixtureBase
    {
        public NHEmployeeModelRepository_AddEmployee() : base(typeof(HeadSpringRolodexProject.Infrastructure.NHibernate.Mappings.EmployeeModelMapping).Assembly) { }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            this.Dispose();
        }

        [Test]
        public void AddEmployee_AddOneEmployee_SavesCorrectly()
        {
            var employeeRepo = new NHEmployeeModelRepository(SessionFactory);
            var employeeModel = new EmployeeModel
            {
                FistName = "John",
                LastName = "Smith",
                Location = "Austin, TX",
                JobTitle = "Engineer",
                Email = "John.Smith@gmail.com"
            };

            employeeRepo.Add(employeeModel);
        }
    }
}
