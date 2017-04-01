using System;
using System.Data;
using HeadSpringRolodexProject.Core.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace HeadSpringRolodexProject.Core.Web.DataAccessLayer
{
    public class EmployeeRolodexContext : DbContext
    {
        public EmployeeRolodexContext(DbContextOptions<EmployeeRolodexContext> options)
            : base(options)
        { }

        public DbSet<BranchLocation> BranchLocationModels { get; set; }
        public DbSet<Employee> EmployeeModels { get; set; }
        public DbSet<PhoneNumber> PhoneNumberModels { get; set; }

        public void BeginTransaction()
        {
            try
            {
                if (Database.CurrentTransaction != null)
                {
                    return;
                }

                Database.BeginTransaction(IsolationLevel.ReadCommitted);
            }
            catch (Exception)
            {
                // todo: log transaction exception
                throw;
            }
        }

        public void CloseTransaction()
        {
            CloseTransaction(exception: null);
        }

        public void CloseTransaction(Exception exception)
        {
            try
            {
                if (Database.CurrentTransaction != null && exception != null)
                {
                    // todo: log exception
                    Database.CurrentTransaction.Rollback();
                    return;
                }

                SaveChanges();

                Database.CurrentTransaction?.Commit();
            }
            catch (Exception)
            {
                // todo: log exception
                Database.CurrentTransaction?.Rollback();

                throw;
            }
            finally
            {
                Database.CurrentTransaction?.Dispose();
            }
        }
    }
}
