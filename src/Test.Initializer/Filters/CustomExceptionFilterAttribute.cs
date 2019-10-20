using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace Test.Initializer.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IHostEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        private readonly ILogger _logger;

        public CustomExceptionFilterAttribute(
            IHostEnvironment hostingEnvironment,
            IModelMetadataProvider modelMetadataProvider,
            ILoggerFactory loggerFactory)
        {
            _hostingEnvironment = hostingEnvironment;
            _modelMetadataProvider = modelMetadataProvider;

            _logger = loggerFactory.CreateLogger<CustomExceptionFilterAttribute>();
        }

        public override void OnException(ExceptionContext context)
        {
            if (!_hostingEnvironment.IsDevelopment())
            {
                // do nothing
                return;
            }

            var exception = context.Exception;
            
            var controller = context.ActionDescriptor.RouteValues["controller"];
            var action = context.ActionDescriptor.RouteValues["action"];
            var message = controller + "/" + action + ": " + exception.Message;

            _logger.LogError(null, exception, message);

            var objectResult = context.Result as ObjectResult;
            context.Result = new BadRequestObjectResult(new BaseResultModel(code: (int)HttpStatusCode.BadRequest, message: message));
        }
    }
}
