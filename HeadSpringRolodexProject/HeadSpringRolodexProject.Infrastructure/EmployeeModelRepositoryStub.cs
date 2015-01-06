using HeadSpringRolodexProject.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadSpringRolodexProject.Core.Models;

namespace HeadSpringRolodexProject.Infrastructure
{
    //this class returns dummy data so we can implement the repo layer later
    public class EmployeeModelRepositoryStub: IEmployeeModelRepository
    {
        private List<EmployeeModel> _employeeList;

        public EmployeeModelRepositoryStub() {
            _employeeList = new List<EmployeeModel>();
            var branchLocation1 = BranchLocationModel.Create(1, "Austin", "TX");
            var phoneNumberList1 = new List<PhoneNumberModel>();
            phoneNumberList1.Add(PhoneNumberModel.Create(1, PhoneNumberType.Home, "(330)234-2342"));
            phoneNumberList1.Add(PhoneNumberModel.Create(2, PhoneNumberType.Mobile, "(440)124-2342"));
            _employeeList.Add(EmployeeModel.Create(1, "John", "Smith", "Engineer", phoneNumberList1, "john.smith@gmail.com", branchLocation1));

            var branchLocation2 = BranchLocationModel.Create(2, "Wadsworth", "OH");
            var phoneNumberList2 = new List<PhoneNumberModel>();
            phoneNumberList2.Add(PhoneNumberModel.Create(3, PhoneNumberType.Home, "(234)234-1231"));
            phoneNumberList2.Add(PhoneNumberModel.Create(4, PhoneNumberType.Mobile, "(330)123-1235"));
            _employeeList.Add(EmployeeModel.Create(2, "Dudley", "Miller", "Chef", phoneNumberList2, "dudley.miller@gmail.com", branchLocation2));
      
            var branchLocation3 = BranchLocationModel.Create(3, "Denver", "CO");
            var phoneNumberList3 = new List<PhoneNumberModel>();
            phoneNumberList2.Add(PhoneNumberModel.Create(5, PhoneNumberType.Home, "(234)234-1231"));
            phoneNumberList2.Add(PhoneNumberModel.Create(6, PhoneNumberType.Mobile, "(330)123-1235"));
            _employeeList.Add(EmployeeModel.Create(3, "Buddy", "Holly", "Engineer", phoneNumberList3, "buddy.holly@aol.com", branchLocation3));
        }

        public void Add(Core.Models.EmployeeModel employee)
        {
            _employeeList.Add(employee);
        }

        public List<Core.Models.EmployeeModel> GetEmployeesBySearchString(string searchString)
        {
            var results = (from emp in _employeeList
                          where emp.FistName.Contains(searchString) ||
                          emp.LastName.Contains(searchString)
                          select emp).ToList();

            return results;
        }

        public void Remove(Core.Models.EmployeeModel employee)
        {
            var employeeToRemove = _employeeList.Find(X => X.EmployeeId == employee.EmployeeId);
            _employeeList.Remove(employeeToRemove);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Core.Models.EmployeeModel employee)
        {
            var employeeToUpdate = _employeeList.Find(X => X.EmployeeId == employee.EmployeeId);

        }


        public EmployeeModel GetById(int employeeId)
        {
            return _employeeList.FirstOrDefault(x => x.EmployeeId == employeeId);
        }
    }
}
