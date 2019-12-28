using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace H.Initializer
{
    public class InitializerMiddlewareExtensions
    {
        private readonly RequestDelegate _next;

        public InitializerMiddlewareExtensions(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (GlobalVariable.CanConnect)
            {
                await _next(context);
                return;
            }

            string currentUrl = context.Request.Scheme + "://" + context.Request.Host + context.Request.Path;
            string databaseCreateUrl = context.Request.Scheme + "://" + context.Request.Host + GlobalVariable.DatabaseCreateUrl;
            if (currentUrl == databaseCreateUrl)
            {
                await _next(context);
                return;
            }

            try
            {
                bool canConnect = GlobalVariable.DbContext.Database.CanConnect();
                if (!canConnect)
                {
                    context.Response.Redirect(databaseCreateUrl);
                    return;
                }
                else
                {
                    GlobalVariable.CanConnect = true;
                    await _next(context);
                }
            }
            catch
            {
                string databaseExceptionUrl = context.Request.Scheme + "://" + context.Request.Host + GlobalVariable.InitExceptionUrl;
                if(currentUrl == databaseExceptionUrl)
                {
                    await _next(context);
                    return;
                }
                context.Response.Redirect(databaseExceptionUrl);
                return;
            }
        }
    }
}
