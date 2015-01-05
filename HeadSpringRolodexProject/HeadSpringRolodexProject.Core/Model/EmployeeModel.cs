using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadSpringRolodexProject.Core.Model
{
    public class EmployeeModel
    {
        public virtual int EmployeeId { get; protected set; }
        public virtual string FistName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string JobTitle { get; set; }
        public virtual List<PhoneNumberModel> PhoneNumbers { get; set; }
        public virtual string Email { get; set; }
        public virtual string Location { get; set; }

        public static EmployeeModel Create(int employeeId, string firstName, string lastName, string jobTitle, List<PhoneNumberModel> phoneNumbers, string email, string location)
        {
            return new EmployeeModel
            {
                EmployeeId = employeeId,
                FistName = firstName,
                LastName = lastName,
                JobTitle = jobTitle,
                PhoneNumbers = phoneNumbers,
                Email = email,
                Location = location
            };
        }

    }
}
