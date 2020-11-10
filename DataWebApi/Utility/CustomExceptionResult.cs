using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataWebApi.Utility
{
    public class CustomExceptionResult : ObjectResult
    {
        public CustomExceptionResult(int? code, Exception exception)
                : base(new CustomExceptionResultModel(code, exception))
        {
            StatusCode = code;
        }
    }
}
