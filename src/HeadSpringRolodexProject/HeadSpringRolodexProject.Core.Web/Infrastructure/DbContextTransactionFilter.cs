using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HeadSpringRolodexProject.Core.Web.Infrastructure
{
    public class DbContextTransactionFilter : IAsyncActionFilter
    {
        private readonly EmployeeRolodexContext _dbContext;

        public DbContextTransactionFilter(EmployeeRolodexContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            try
            {
                _dbContext.BeginTransaction();

                await next();

                await _dbContext.CommitTransactionAsync();
            }
            catch (Exception)
            {
                _dbContext.RollbackTransaction();
                throw;
            }
        }
    }
}
