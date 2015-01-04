using HeadSpringRolodexProject.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadSpringRolodexProject.Core.Model;

namespace HeadSpringRolodexProject.Infrastructure
{
    //this class returns dummy data so we can implement the repo layer later
    public class EmployeeModelRepositoryStub: IEmployeeModelRepository
    {
        private List<EmployeeModel> _employeeList;

        public EmployeeModelRepositoryStub() {
            _employeeList = new List<EmployeeModel>();
            var phoneNumberList1 = new List<PhoneNumberModel>();
            phoneNumberList1.Add(new PhoneNumberModel
            {
                Number = "(330)234-2342",
                PhoneType = PhoneNumberType.Home
            });
            phoneNumberList1.Add(new PhoneNumberModel
            {
                Number = "(440)124-2342",
                PhoneType = PhoneNumberType.Mobile
            });
            _employeeList.Add(EmployeeModel.Create(1, "John", "Smith", "Engineer", phoneNumberList1, "john.smith@gmail.com", "Austin,TX"));

            var phoneNumberList2 = new List<PhoneNumberModel>();
            phoneNumberList2.Add(new PhoneNumberModel
            {
                Number = "(234)234-1231",
                PhoneType = PhoneNumberType.Home
            });
            phoneNumberList2.Add(new PhoneNumberModel
            {
                Number = "(330)123-1235",
                PhoneType = PhoneNumberType.Mobile
            });

            _employeeList.Add(EmployeeModel.Create(2, "Dudley", "Miller", "Chef", phoneNumberList2, "dudley.miller@gmail.com", "Wadsworth, OH"));

            var phoneNumberList3 = new List<PhoneNumberModel>();
            phoneNumberList2.Add(new PhoneNumberModel
            {
                Number = "(234)234-1231",
                PhoneType = PhoneNumberType.Home
            });
            phoneNumberList2.Add(new PhoneNumberModel
            {
                Number = "(330)123-1235",
                PhoneType = PhoneNumberType.Mobile
            });

            _employeeList.Add(EmployeeModel.Create(3, "Buddy", "Holly", "Engineer", phoneNumberList3, "buddy.holly@aol.com", "Denver, CO"));
        }

        public void Add(Core.Model.EmployeeModel employee)
        {
            _employeeList.Add(employee);
        }

        public List<Core.Model.EmployeeModel> GetEmployeesBySearchString(string searchString)
        {
            var results = (from emp in _employeeList
                          where emp.FistName.Contains(searchString) ||
                          emp.LastName.Contains(searchString)
                          select emp).ToList();

            return results;
        }

        public void Remove(Core.Model.EmployeeModel employee)
        {
            var employeeToRemove = _employeeList.Find(X => X.Id == employee.Id);
            _employeeList.Remove(employeeToRemove);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Core.Model.EmployeeModel employee)
        {
            var employeeToUpdate = _employeeList.Find(X => X.Id == employee.Id);

        }
    }
}
