using System;

namespace Stockpot.WebApi.ResponseObjects
{
    public class ExceptionResponse
    {
        public string Message { get; }

        public ExceptionResponse(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("Message can not be null or empty.", nameof(message));
            }

            Message = message;
        }
    }
}