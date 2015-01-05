using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HeadSpringRolodexProject.Web.Infrastructure.Mapping;
using HeadSpringRolodexProject.Core.Model;

namespace HeadSpringRolodexProject.Web.Models
{
    public class EmployeeRolodexViewModel
    {
        public List<EmployeeViewModel> Employees { get; set; }
    }

    public class EmployeeViewModel:IMapFrom<EmployeeModel>
    {
        public int EmployeeId { get; set; }
        [Required]
        public string FistName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string JobTitle { get; set; }
        public List<PhoneNumberModelViewModel> PhoneNumbers { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Location { get; set; }

    }

    public class PhoneNumberModelViewModel:IMapFrom<PhoneNumberModel>
    {
        public int PhoneNumberId { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}