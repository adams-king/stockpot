using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Stockpot.WebApi.ResponseObjects;

namespace Stockpot.WebApi.Misc
{
    public class ValidateModelFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var logger = context.HttpContext.RequestServices.GetService(typeof(ILogger<ValidateModelFilterAttribute>))
                as ILogger<ValidateModelFilterAttribute>;

            if (!context.ModelState.IsValid)
            {
                logger.LogWarning("Validation Error", context.ModelState);
                context.Result = new BadRequestObjectResult(new BadRequestResponse(context.ModelState));
            }

            base.OnActionExecuting(context);
        }
    }
}