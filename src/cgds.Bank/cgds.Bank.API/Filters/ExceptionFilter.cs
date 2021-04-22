using cgds.Bank.API.Models;
using cgds.Bank.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace cgds.Bank.API.Filters
{
    public class ExceptionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is BankException exception)
            {
                var exceptionResponse = new ExceptionResponse
                {
                    StatusCode = (int)HttpStatusCode.UnprocessableEntity,
                    Message = exception.Message
                };
                context.Result = new ObjectResult(exceptionResponse)
                {
                    StatusCode = exceptionResponse.StatusCode
                };
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context) { }
    }
}
