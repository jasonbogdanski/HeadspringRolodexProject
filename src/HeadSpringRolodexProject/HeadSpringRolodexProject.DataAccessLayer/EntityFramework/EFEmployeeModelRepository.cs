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
        private EmployeeContext _context;

        public EFEmployeeModelRepository(EmployeeContext context)
        {
            _context = context;
        }

        public void Add(Core.Models.EmployeeModel employee)
        {
            employee.BranchLocation = _context.BranchLocations.FirstOrDefault(x => x.BranchLocationId == employee.BranchLocation.BranchLocationId);
            _context.Employees.Add(employee);           
        }

        public List<Core.Models.EmployeeModel> GetEmployeesBySearchString(string searchString)
        {
            return (from emp in _context.Employees.Include(x=>x.PhoneNumbers).Include(x=>x.BranchLocation)
                    where emp.FistName.ToLower().Contains(searchString.ToLower()) ||
                        emp.LastName.ToLower().Contains(searchString.ToLower()) ||
                        emp.Email.ToLower().Contains(searchString.ToLower()) ||
                        emp.JobTitle.ToLower().Contains(searchString.ToLower()) ||
                        emp.PhoneNumbers.FirstOrDefault(x=>x.Number.ToLower().Contains(searchString.ToLower())) != null ||
                        emp.BranchLocation.City.ToLower().Contains(searchString.ToLower()) ||
                        emp.BranchLocation.State.ToLower().Contains(searchString.ToLower())
                       
                    select emp).ToList();
        }

        public void Remove(int employeeId)
        {
            var employee = _context.Employees.Include(x => x.PhoneNumbers).FirstOrDefault(x => x.EmployeeId == employeeId);
            _context.Employees.Remove(employee);
        }

        public void Update(Core.Models.EmployeeModel updatedEmployee)
        {

        }

        public Core.Models.EmployeeModel GetById(int employeeId)
        {
             return _context.Employees.Include(x=>x.PhoneNumbers).Include(x=>x.BranchLocation).FirstOrDefault(x => x.EmployeeId == employeeId);
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


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
