using FluentValidation;
using Jex.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Jex.Api.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() != typeof(ContentValidationException))
            {
                base.OnException(context);
                return;
            }

            var ex = context.Exception as ContentValidationException;

            var details = new ValidationProblemDetails(ex.Errors);
            context.Result = new BadRequestObjectResult(details);
            context.ExceptionHandled = true;
        }
    }
}
