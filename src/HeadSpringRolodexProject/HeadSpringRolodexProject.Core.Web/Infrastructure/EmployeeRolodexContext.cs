using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Threading.Tasks;
using HeadSpringRolodexProject.Core.Web.Domain;

namespace HeadSpringRolodexProject.Core.Web.Infrastructure
{
    public class EmployeeRolodexContext : DbContext
    {
        private DbContextTransaction _currentTransaction;

        public EmployeeRolodexContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<BranchLocation> BranchLocations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public void BeginTransaction()
        {
            if (_currentTransaction != null)
            {
                return;
            }

            _currentTransaction = Database.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync();

                _currentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}
