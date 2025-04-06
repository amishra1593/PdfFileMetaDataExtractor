using FileUploaderSample.Responses.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Serilog;

namespace FileUploaderSample.Filters
{
    public class ErrorHandlingFilter : IExceptionFilter
    {

        public void OnException(ExceptionContext context)
        {

            Log.Error(context.Exception, "An unhandled exception occurred: {Message}", context.Exception.Message);
            SetResponse(context);
            context.ExceptionHandled = true;
        }

        private void SetResponse(ExceptionContext context)
        {
            context.Result = new ObjectResult(new
            {
                message = "An error occurred while processing your request. Please try again later.",
                detail = context.Exception.Message
            })
            {
                StatusCode = 500
            };
        }
    }
}
