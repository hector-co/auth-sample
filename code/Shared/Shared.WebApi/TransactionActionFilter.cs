using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Shared.WebApi.ExceptionHandling;
using System.Net;

namespace Shared.WebApi
{
    public class TransactionActionFilter<TContext> : IAsyncActionFilter
        where TContext : DbContext
    {
        private readonly TContext _context;

        public TransactionActionFilter(TContext context) => _context = context;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var transaction = await _context.Database.BeginTransactionAsync();

            var executed = await next();

            if (executed.Exception != null)
            {
                await transaction.RollbackAsync();
                return;
            }

            try
            {
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ApiException("Errors when persisting data.", HttpStatusCode.InternalServerError, ApiException.DataAccessError, innerException: ex);
            }
        }
    }
}
