using HeadSpringRolodexProject.Core.Interfaces;
using HeadSpringRolodexProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadSpringRolodexProject.Core.Services
{
    public class EmployeeRolodexService : IEmployeeRolodexService
    {
        private readonly IEmployeeModelRepository _employeeModelRepository;

        public EmployeeRolodexService()
        {

        }

        public EmployeeRolodexService(IEmployeeModelRepository employeeModelRepository)
        {
            _employeeModelRepository = employeeModelRepository;
        } 

        public List<EmployeeModel> GetEmployeesBySearchString(string searchString)
        {
            if(!String.IsNullOrEmpty(searchString))
            {
                return _employeeModelRepository.GetEmployeesBySearchString(searchString);
            }
            else
            {
                return new List<EmployeeModel>();
            }
            
        }

        public EmployeeModel GetById(int employeeId)
        {
            return _employeeModelRepository.GetById(employeeId);   
        }

        public void Update(EmployeeModel employee)
        {
            _employeeModelRepository.Update(employee);
        }

        public void Add(EmployeeModel employee)
        {
            _employeeModelRepository.Add(employee);
        }

        public void Remove(int employeeId)
        {
            _employeeModelRepository.Remove(employeeId);
        }
    }
}
