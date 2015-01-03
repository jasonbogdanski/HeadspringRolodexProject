using HeadSpringRolodexProject.Core.Interfaces;
using HeadSpringRolodexProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadSpringRolodexProject.Core.Services
{
    public class EmployeeRolodexService
    {
        private readonly IEmployeeModelRepository _employeeModelRepository;

        public EmployeeRolodexService(IEmployeeModelRepository employeeModelRepository)
        {
            _employeeModelRepository = employeeModelRepository;
        } 

        public List<EmployeeModel> GetEmployeesBySearchString(string searchString)
        {
            return _employeeModelRepository.GetEmployeesBySearchString(searchString);
        }
    }
}
