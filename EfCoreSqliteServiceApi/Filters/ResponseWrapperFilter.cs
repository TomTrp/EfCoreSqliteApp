using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using EfCoreSqliteLibs.Models;

namespace EfCoreSqliteServiceApi.Filters
{
    public class ResponseWrapperFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null) return;

            var traceId = context.HttpContext.TraceIdentifier;

            if (context.Result is ObjectResult objectResult)
            {
                var wrapped = new ResponseModel<object>
                {
                    IsSuccess = true,
                    StatusCode = objectResult.StatusCode ?? 200,
                    Message = "Success",
                    TaceId = traceId,
                    DataResult = objectResult.Value
                };

                context.Result = new JsonResult(wrapped)
                {
                    StatusCode = objectResult.StatusCode
                };
            }
            else if (context.Result is EmptyResult)
            {
                var wrapped = new ResponseModel<object>
                {
                    IsSuccess = true,
                    StatusCode = 204,
                    Message = "No content",
                    TaceId = traceId,
                    DataResult = null
                };

                context.Result = new JsonResult(wrapped)
                {
                    StatusCode = 200
                };
            }
        }
    }
}
