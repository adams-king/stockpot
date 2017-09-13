using System.Net;

namespace Stockpot.WebApi.ResponseObjects
{
    public class StatusCodeResponse
    {
        public int StatusCode { get; }

        public string Description { get; }

        public StatusCodeResponse(int httpStatusCode)
        {
            StatusCode = httpStatusCode;
            Description = ((HttpStatusCode)httpStatusCode).ToString();
        }
    }
}