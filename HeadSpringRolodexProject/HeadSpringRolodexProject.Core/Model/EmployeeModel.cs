using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadSpringRolodexProject.Core.Model
{
    public class EmployeeModel
    {
        public virtual int Id { get; protected set; }
        public virtual string FistName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string JobTitle { get; set; } 
        public virtual string HomeNumber { get; set; }
        public virtual string MobileNumber { get; set; }
        public virtual string Email { get; set; }
        public virtual string Location { get; set; }

    }
}
