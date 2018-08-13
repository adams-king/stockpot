using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stockpot.WebApi.ResponseObjects
{
    public class BadRequestResponse
    {
        public IEnumerable<string> Errors { get; }

#if DEBUG
        public IEnumerable<string> Exceptions { get; }
#endif

        public BadRequestResponse(ModelStateDictionary modelState)
        {
            if (modelState.IsValid)
            {
                throw new ArgumentException("ModelState must be invalid.", nameof(modelState));
            }

            Errors = modelState
                .SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage)
                .ToArray();

#if DEBUG
            Exceptions = modelState
                .SelectMany(x => x.Value.Errors)
                .Select(x => x.Exception?.Message)
                .ToArray();
#endif
        }
    }
}
