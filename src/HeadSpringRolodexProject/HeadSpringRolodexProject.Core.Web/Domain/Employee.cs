using System.Collections.Generic;

namespace HeadSpringRolodexProject.Core.Web.Domain
{
    public class Employee : IEntity
    {
        public Employee()
        {
            PhoneNumbers = new List<PhoneNumber>();
        }
        public virtual int Id { get; set; }
        public virtual string FistName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string JobTitle { get; set; }
        public virtual List<PhoneNumber> PhoneNumbers { get; set; }
        public virtual string Email { get; set; }
        public virtual BranchLocation BranchLocation { get; set; }

        public static Employee Create(int employeeId, string firstName, string lastName, string jobTitle, List<PhoneNumber> phoneNumbers, string email, BranchLocation branchLocation)
        {
            return new Employee
            {
                Id = employeeId,
                FistName = firstName,
                LastName = lastName,
                JobTitle = jobTitle,
                PhoneNumbers = phoneNumbers,
                Email = email,
                BranchLocation = branchLocation
            };
        }

    }
}
