using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataWebApi.Utility
{
    public class ValidationFailedResult : ObjectResult
    {

        public ValidationFailedResult(ModelStateDictionary modelState)
              : base(new ValidationFailedResultModel(modelState))
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }
    }
}
