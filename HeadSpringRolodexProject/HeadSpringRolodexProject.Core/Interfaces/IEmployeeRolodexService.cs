using System;
namespace HeadSpringRolodexProject.Core.Interfaces
{
    public interface IEmployeeRolodexService
    {
        void Add(HeadSpringRolodexProject.Core.Model.EmployeeModel employee);
        System.Collections.Generic.List<HeadSpringRolodexProject.Core.Model.EmployeeModel> GetEmployeesBySearchString(string searchString);
        void Remove(HeadSpringRolodexProject.Core.Model.EmployeeModel employee);
        void Update(HeadSpringRolodexProject.Core.Model.EmployeeModel employee);
    }
}
