using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadSpringRolodexProject.Core.Interfaces;
using HeadSpringRolodexProject.Core.Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeadSpringRolodexProject.DataAccessLayer.EntityFramework
{
    public class EFEmployeeModelRepository : IEmployeeModelRepository
    {
        public void Add(Core.Models.EmployeeModel employee)
        {
            using (var db = new EmployeeContext())
            {
                employee.BranchLocation = db.BranchLocations.FirstOrDefault(x => x.BranchLocationId == employee.BranchLocation.BranchLocationId);
                db.Employees.Add(employee);           
                db.SaveChanges();
            }
        }

        public List<Core.Models.EmployeeModel> GetEmployeesBySearchString(string searchString)
        {
            using (var db = new EmployeeContext())
            {
                return (from emp in db.Employees.Include(x=>x.PhoneNumbers).Include(x=>x.BranchLocation)
                        where emp.FistName.ToLower().Contains(searchString.ToLower()) ||
                          emp.LastName.ToLower().Contains(searchString.ToLower()) ||
                          emp.Email.ToLower().Contains(searchString.ToLower()) ||
                          emp.JobTitle.ToLower().Contains(searchString.ToLower()) ||
                          emp.PhoneNumbers.FirstOrDefault(x=>x.Number.ToLower().Contains(searchString.ToLower())) != null
                       
                        select emp).ToList();
            }
        }

        public void Remove(int employeeId)
        {
            using (var db = new EmployeeContext())
            {
                var employee = db.Employees.Include(x => x.PhoneNumbers).FirstOrDefault(x => x.EmployeeId == employeeId);
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
        }

        public void Update(Core.Models.EmployeeModel updatedEmployee)
        {
            using (var db = new EmployeeContext())
            {
                var employeeInDB = db.Employees.Include(x => x.PhoneNumbers).Include(x => x.BranchLocation).FirstOrDefault(x => x.EmployeeId == updatedEmployee.EmployeeId);
                employeeInDB.BranchLocation = db.BranchLocations.FirstOrDefault(x => x.BranchLocationId == updatedEmployee.BranchLocation.BranchLocationId);
                employeeInDB.FistName = updatedEmployee.FistName;
                employeeInDB.LastName = updatedEmployee.LastName;
                employeeInDB.JobTitle = updatedEmployee.JobTitle;
                employeeInDB.Email = updatedEmployee.Email;
                UpdatePhoneNumbers(updatedEmployee, employeeInDB);
         
                db.SaveChanges();
            }
        }

        private void UpdatePhoneNumbers(EmployeeModel updatedEmployee, EmployeeModel existingEmployee)
        {
            var phoneNumbers = new List<PhoneNumberModel>();
            UpdatePhoneNumbers(updatedEmployee.PhoneNumbers.FirstOrDefault(x=>x.PhoneType == PhoneNumberType.Home), PhoneNumberType.Home, existingEmployee);
            UpdatePhoneNumbers(updatedEmployee.PhoneNumbers.FirstOrDefault(x=>x.PhoneType == PhoneNumberType.Mobile), PhoneNumberType.Mobile, existingEmployee);
            UpdatePhoneNumbers(updatedEmployee.PhoneNumbers.FirstOrDefault(x=>x.PhoneType == PhoneNumberType.Other), PhoneNumberType.Other, existingEmployee);
        }

        private void UpdatePhoneNumbers(PhoneNumberModel phoneNumber, PhoneNumberType phoneType, EmployeeModel existingEmployee) {
            if (phoneNumber != null)
            {
                var phone = existingEmployee.PhoneNumbers.FirstOrDefault(x => x.PhoneType == phoneType);
                if (phone != null)
                {
                    phone.Number = phoneNumber.Number;
                }
                else
                {
                    existingEmployee.PhoneNumbers.Add(PhoneNumberModel.Create(0, phoneType, phoneNumber.Number));
                }
            }
        }

        public Core.Models.EmployeeModel GetById(int employeeId)
        {
            using (var db = new EmployeeContext())
            {
                return db.Employees.Include(x=>x.PhoneNumbers).Include(x=>x.BranchLocation).FirstOrDefault(x => x.EmployeeId == employeeId);
            }
        }

        public class EmployeeContext : DbContext
        {
            public DbSet<EmployeeModel> Employees { get; set; }
            public DbSet<BranchLocationModel> BranchLocations { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<EmployeeModel>().HasKey(x => x.EmployeeId);
                modelBuilder.Entity<EmployeeModel>().ToTable("Employee");
                modelBuilder.Entity<PhoneNumberModel>().HasKey(x => x.PhoneNumberId);
                modelBuilder.Entity<PhoneNumberModel>().ToTable("PhoneNumber");
                modelBuilder.Entity<BranchLocationModel>().HasKey(x => x.BranchLocationId);
                modelBuilder.Entity<BranchLocationModel>().ToTable("BranchLocation");
            } 
        }
    }
}
