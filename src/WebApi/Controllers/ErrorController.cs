using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Stockpot.WebApi.ResponseObjects;
using System.Text;

namespace Stockpot.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : Controller
    {
        private readonly IHostingEnvironment _env;

        public ErrorController(IHostingEnvironment env)
        {
            _env = env;
        }

        [Route("{httpStatusCode}")]
        public IActionResult Code(int httpStatusCode)
        {
            return new ObjectResult(new StatusCodeResponse(httpStatusCode));
        }

        [Route("[action]")]
        public IActionResult Exception()
        {
            // Return simple error when not in development mode.
            if (!_env.IsDevelopment())
            {
                return new ObjectResult(new ExceptionResponse("Internal server error."));
            }

            var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = feature.Error;
            var sb = new StringBuilder();

            while (exception != null)
            {
                sb.AppendLine(exception.Message);
                exception = exception.InnerException;
            }

            var message = sb.ToString();
            message = string.IsNullOrEmpty(message) ? "Unknown error" : message;

            return new ObjectResult(new ExceptionResponse(message));
        }
    }
}