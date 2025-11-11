using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using TaskManager.Utils;

namespace TaskManager.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var statusCode = HttpStatusCode.InternalServerError;

            if (context.Exception.GetType().Name.ToLower().Contains("bad") || context.Exception.GetType().Name.ToLower().Contains("invalid"))
            {
                context.Result = new BadRequestObjectResult(new ApiNotification<object>()
                {
                    Success = false,
                    Data = { },
                    Notifications = new List<string>() { context.Exception.Message }
                });
            }
            else
            if (context.Exception.GetType().Name.ToLower().Contains("unauthorized"))
            {
                context.Result = new UnauthorizedObjectResult(new ApiNotification<object>()
                {
                    Success = false,
                    Data = { },
                    Notifications = new List<string>() { context.Exception.Message }
                });
            }
            else
            if (context.Exception.GetType().Name.ToLower().Contains("notfound"))
            {
                context.Result = new NotFoundObjectResult(new ApiNotification<object>()
                {
                    Success = false,
                    Data = { },
                    Notifications = new List<string>() { context.Exception.Message }
                });
            }
            else
                context.Result = new ObjectResult(new ApiNotification<object>()
                {
                    Success = false,
                    Data = { },
                    Notifications = new List<string>() { context.Exception.Message }
                })
                {
                    StatusCode = 500
                };
            context.ExceptionHandled = true;
        }
    }
}
