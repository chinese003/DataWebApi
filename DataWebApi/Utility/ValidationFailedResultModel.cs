using DataWebApi.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataWebApi.Utility
{
    public class ValidationFailedResultModel : BaseResultModel
    {
        public ValidationFailedResultModel(ModelStateDictionary modelState)
        {
            Code = 422;
            Message = "参数不合法";
            Result = modelState.Keys
                        .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                        .ToList();
            ReturnStatus = ReturnStatus.Fail;
        }
    }

    
}
