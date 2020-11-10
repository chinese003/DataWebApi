using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DataWebApi.Utility
{
    public class CustomExceptionAttribute : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;

            //处理各种异常

            context.ExceptionHandled = true;
            context.Result = new CustomExceptionResult((int)status, context.Exception);
        }
    }
}
