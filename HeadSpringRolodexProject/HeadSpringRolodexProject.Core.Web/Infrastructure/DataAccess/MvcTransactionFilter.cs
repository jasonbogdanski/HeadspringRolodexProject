using System;
using HeadSpringRolodexProject.Core.Web.DataAccessLayer;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HeadSpringRolodexProject.Core.Web.Infrastructure.DataAccess
{
    public class MvcTransactionFilter : ActionFilterAttribute
    {
        private readonly EmployeeRolodexContext _dbContext;

        public MvcTransactionFilter(EmployeeRolodexContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _dbContext.CloseTransaction(context.Exception);
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _dbContext.BeginTransaction();
        }
    }
}
