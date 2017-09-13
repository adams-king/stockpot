using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Stockpot.WebApi.ResponseObjects;

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
            var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var error = feature?.Error;
            var message = error == null
                ? "Unknown error"
                : error.Message;

            // Return simple error when not in development mode.
            if (!_env.IsDevelopment())
            {
                return new ObjectResult(new ExceptionResponse("Internal server error."));
            }

            return new ObjectResult(new ExceptionResponse(message));
        }
    }
}