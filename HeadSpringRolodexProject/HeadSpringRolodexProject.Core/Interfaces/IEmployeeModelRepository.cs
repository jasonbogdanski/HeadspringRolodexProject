using HeadSpringRolodexProject.Core.Models;
using System;
namespace HeadSpringRolodexProject.Core.Interfaces
{
    public interface IEmployeeModelRepository
    {
        void Add(HeadSpringRolodexProject.Core.Models.EmployeeModel employee);
        System.Collections.Generic.List<HeadSpringRolodexProject.Core.Models.EmployeeModel> GetEmployeesBySearchString(string searchString);
        void Remove(int employeeId);
        void Update(HeadSpringRolodexProject.Core.Models.EmployeeModel employee);
        EmployeeModel GetById(int employeeId);
        void Save();
    }
}
