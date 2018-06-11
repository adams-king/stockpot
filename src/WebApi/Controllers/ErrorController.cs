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
            string message = "Internal Server Error";

            // Create detailed message when in development mode.
            if (_env.IsDevelopment())
            {
                var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();
                var exception = feature.Error;
                var sb = new StringBuilder();

                while (exception != null)
                {
                    sb.AppendLine(exception.Message);
                    exception = exception.InnerException;
                }

                message = sb.ToString().Trim();

                message = string.IsNullOrEmpty(message) ? "Unknown Error" : message;
            }

            return new ObjectResult(new ExceptionResponse(message));
        }
    }
}
