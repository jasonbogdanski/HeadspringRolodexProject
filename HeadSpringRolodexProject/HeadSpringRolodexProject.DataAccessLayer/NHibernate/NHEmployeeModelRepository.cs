using HeadSpringRolodexProject.Core.Models;
using HeadSpringRolodexProject.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace HeadSpringRolodexProject.DataAccessLayer.NHibernate
{
    public class NHEmployeeModelRepository : IEmployeeModelRepository
    {

        private readonly ISessionFactory _sessionFactory;

        public NHEmployeeModelRepository(ISessionFactory sessionFactory)
        {
            this._sessionFactory = sessionFactory;
        }

        //TODO Complete NH Repository
        public List<EmployeeModel> GetEmployeesBySearchString(string searchString)
        {
            var employeeList = new List<EmployeeModel>();
                employeeList.Add(new EmployeeModel()
                {
                    FistName = "John"
                }
            );

            return employeeList;
        }

        public void Add(EmployeeModel employee) 
        {
            using(var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(employee);
                transaction.Commit();
            }
        }

        public void Remove(EmployeeModel employee)
        {

        }

        public void Update(EmployeeModel employee)
        {

        }

        public void Save()
        {
            
        }


        public EmployeeModel GetById(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
