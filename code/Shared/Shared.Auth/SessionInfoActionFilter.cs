using Microsoft.AspNetCore.Mvc.Filters;

namespace Shared.Auth
{
    public class SessionInfoActionFilter : IAsyncActionFilter
    {
        private readonly SessionInfo _sessionInfo;

        public SessionInfoActionFilter(SessionInfo sessionInfo)
        {
            _sessionInfo = sessionInfo;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.User.Identity?.IsAuthenticated ?? false)
                _sessionInfo.SetData(context.HttpContext);

            await next();
        }
    }
}
