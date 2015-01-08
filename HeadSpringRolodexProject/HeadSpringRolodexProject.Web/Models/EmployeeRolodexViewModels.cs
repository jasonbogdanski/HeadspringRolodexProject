using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HeadSpringRolodexProject.Web.Infrastructure.Mapping;
using HeadSpringRolodexProject.Core.Models;
using System.Web.Mvc;

namespace HeadSpringRolodexProject.Web.Models
{
    public class EmployeeRolodexViewModel
    {
        public EmployeeRolodexViewModel()
        {
            Employees = new List<EmployeeViewModel>();
        }

        public List<EmployeeViewModel> Employees { get; set; }
        public bool IsHR { get; set; }
        public string SearchMessage { get; set; }
    }

    public class EmployeeViewModel
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
        public string HomePhoneNumber { get; set; }
        [Phone]
        [Display(Name = "Mobile Phone Number")]
        public string MobilePhoneNumber { get; set; }
        [Phone]
        [Display(Name = "Other Phone Number")]
        public string OtherPhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Branch Location")]
        public string BranchLocationCity { get; set; }
        [Display(Name = "Branch City")]
        public string BranchLocationState { get; set; }
        [Required]
        [Display(Name = "Branch Location")]
        public int SelectedBranchLocationId { get; set; }

        [Display(Name = "Select Branch Location")]
        public IEnumerable<SelectListItem> BranchLocationList { get; set; }

        public static EmployeeViewModel Create(List<BranchLocationModel> branchLocations)
        {
            return new EmployeeViewModel
            {
                BranchLocationList = MapFrom(branchLocations)
            };
        }

        public static List<SelectListItem> MapFrom(List<BranchLocationModel> branchLocations)
        {
            if (branchLocations != null)
            {
                return branchLocations.Select(x => new SelectListItem()
                {
                    Text = string.Format("{0}, {1}", x.City, x.State),
                    Value = x.BranchLocationId.ToString()
                }).ToList();
            }
            else
            {
                return new List<SelectListItem>();
            }
        }

        public static EmployeeModel MapFrom(EmployeeViewModel employeeViewModel, List<BranchLocationModel> branchLocations)
        {
            return MapFrom(employeeViewModel, new EmployeeModel(), branchLocations);
        }

        public static EmployeeModel MapFrom(EmployeeViewModel employeeViewModel, EmployeeModel existingEmployee, List<BranchLocationModel> branchLocations)
        {
            existingEmployee.EmployeeId = employeeViewModel.EmployeeId;
            existingEmployee.FistName = employeeViewModel.FistName;
            existingEmployee.LastName = employeeViewModel.LastName;
            existingEmployee.JobTitle = employeeViewModel.JobTitle;
            existingEmployee.Email = employeeViewModel.Email;
            existingEmployee.BranchLocation = branchLocations.FirstOrDefault(x => x.BranchLocationId == employeeViewModel.SelectedBranchLocationId);

            MapPhoneNumbers(employeeViewModel, existingEmployee);

            return existingEmployee;
        }

        public static List<EmployeeViewModel> MapFrom(List<EmployeeModel> employees)
        {
            return employees.Select(x => EmployeeViewModel.MapFrom(x)).ToList();
        }

        public static EmployeeViewModel MapFrom(EmployeeModel employee, List<BranchLocationModel> branchLocations = null)
        {
            var employeeViewModel = new EmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                HomePhoneNumber = MapFrom(employee.PhoneNumbers.FirstOrDefault(x=>x.PhoneType == PhoneNumberType.Home)),
                MobilePhoneNumber = MapFrom(employee.PhoneNumbers.FirstOrDefault(x=>x.PhoneType == PhoneNumberType.Mobile)),
                OtherPhoneNumber = MapFrom(employee.PhoneNumbers.FirstOrDefault(x=>x.PhoneType == PhoneNumberType.Other)),
                FistName = employee.FistName,
                LastName = employee.LastName,
                Email = employee.Email,
                JobTitle = employee.JobTitle,
                BranchLocationCity = employee.BranchLocation.City,
                BranchLocationState = employee.BranchLocation.State,
                SelectedBranchLocationId = employee.BranchLocation.BranchLocationId,
                BranchLocationList = MapFrom(branchLocations)
            };

            return employeeViewModel;
        }

        public static string MapFrom(PhoneNumberModel phoneNumber)
        {
            if (phoneNumber != null)
            {
                return phoneNumber.Number;
            }
            else
            {
                return null;
            }

        }

        private static void MapPhoneNumbers(EmployeeViewModel employeeViewModel, EmployeeModel existingEmployee)
        {
            var phoneNumbers = new List<PhoneNumberModel>();
            MapPhone(employeeViewModel.HomePhoneNumber, PhoneNumberType.Home, existingEmployee);
            MapPhone(employeeViewModel.MobilePhoneNumber, PhoneNumberType.Mobile, existingEmployee);
            MapPhone(employeeViewModel.OtherPhoneNumber, PhoneNumberType.Other, existingEmployee);
        }

        private static void MapPhone(string number, PhoneNumberType phoneType, EmployeeModel existingEmployee) {
            if (!string.IsNullOrEmpty(number))
            {
                var phone = existingEmployee.PhoneNumbers.FirstOrDefault(x => x.PhoneType == phoneType);
                if (phone != null)
                {
                    phone.Number = number;
                }
                else
                {
                    existingEmployee.PhoneNumbers.Add(PhoneNumberModel.Create(0, phoneType, number));
                }
            }
            else
            {
                var phone = existingEmployee.PhoneNumbers.FirstOrDefault(x=>x.PhoneType == phoneType);
                if(phone != null) {
                    existingEmployee.PhoneNumbers.Remove(phone);
                }             
            }
        }
    }

    public class BranchLocationViewModel
    {
        public int BranchLocationId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }

}