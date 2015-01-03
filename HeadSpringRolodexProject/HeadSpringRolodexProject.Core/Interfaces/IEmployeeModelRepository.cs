using System;
namespace HeadSpringRolodexProject.Core.Interfaces
{
    public interface IEmployeeModelRepository
    {
        void Add(HeadSpringRolodexProject.Core.Model.EmployeeModel employee);
        System.Collections.Generic.List<HeadSpringRolodexProject.Core.Model.EmployeeModel> GetEmployeesBySearchString(string searchString);
        void Remove(HeadSpringRolodexProject.Core.Model.EmployeeModel employee);
        void Save();
        void Update(HeadSpringRolodexProject.Core.Model.EmployeeModel employee);
    }
}
