using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stockpot.WebApi.ResponseObjects
{
    public class BadRequestResponse
    {
        public IEnumerable<string> Errors { get; }

        public BadRequestResponse(ModelStateDictionary modelState)
        {
            if (modelState.IsValid)
            {
                throw new ArgumentException("ModelState must be invalid.", nameof(modelState));
            }

            Errors = modelState
                .SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage).ToArray();
        }
    }
}