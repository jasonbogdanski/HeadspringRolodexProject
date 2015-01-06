using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HeadSpringRolodexProject.Web.Infrastructure.Mapping;
using HeadSpringRolodexProject.Core.Models;

namespace HeadSpringRolodexProject.Web.Models
{
    public class EmployeeRolodexViewModel
    {
        public List<EmployeeViewModel> Employees { get; set; }
    }

    public class EmployeeViewModel:IHaveCustomMappings
    {
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FistName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        [Phone]
        [Display(Name= "Home Phone Number")]
        public PhoneNumberViewModel HomePhoneNumber { get; set; }
        [Phone]
        [Display(Name = "Mobile Phone Number")]
        public PhoneNumberViewModel MobilePhoneNumber { get; set; }
        [Phone]
        [Display(Name = "Other Phone Number")]
        public PhoneNumberViewModel OtherPhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Location")]
        public BranchLocationViewModel BranchLocation { get; set; }


        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<EmployeeModel, EmployeeViewModel>()
                .ForMember(m => m.HomePhoneNumber,
                    opt => opt.MapFrom(u => u.PhoneNumbers.FirstOrDefault(x => x.PhoneType == PhoneNumberType.Home)))
                .ForMember(m => m.MobilePhoneNumber,
                    opt => opt.MapFrom(u => u.PhoneNumbers.FirstOrDefault(x => x.PhoneType == PhoneNumberType.Mobile)))
                .ForMember(m => m.OtherPhoneNumber,
                    opt => opt.MapFrom(u => u.PhoneNumbers.FirstOrDefault(x => x.PhoneType == PhoneNumberType.Other)));

            configuration.CreateMap<EmployeeViewModel, EmployeeModel>()
                .ForMember(m => m.PhoneNumbers,
                opt => opt.MapFrom(src => src.MapPhoneNumbers(src)));

        }

        public List<PhoneNumberModel> MapPhoneNumbers (EmployeeViewModel employeeViewModel) {

            var phoneNumbers = new List<PhoneNumberModel>();

            if (employeeViewModel.HomePhoneNumber != null)
            {
                phoneNumbers.Add(PhoneNumberModel.Create(employeeViewModel.HomePhoneNumber.PhoneNumberId, PhoneNumberType.Home, employeeViewModel.HomePhoneNumber.Number));
            }

            if (employeeViewModel.MobilePhoneNumber != null)
            {
                phoneNumbers.Add(PhoneNumberModel.Create(employeeViewModel.MobilePhoneNumber.PhoneNumberId, PhoneNumberType.Mobile, employeeViewModel.MobilePhoneNumber.Number));
            }

            if (employeeViewModel.OtherPhoneNumber != null)
            {
                phoneNumbers.Add(PhoneNumberModel.Create(employeeViewModel.OtherPhoneNumber.PhoneNumberId, PhoneNumberType.Other, employeeViewModel.OtherPhoneNumber.Number));
            }

            return phoneNumbers;
        }
    }

    public class BranchLocationViewModel : IMapFrom<BranchLocationModel>
    {
        public int BranchLocationId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }

    public class PhoneNumberViewModel:IMapFrom<PhoneNumberModel>
    {
        public int PhoneNumberId { get; set; }
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }


}