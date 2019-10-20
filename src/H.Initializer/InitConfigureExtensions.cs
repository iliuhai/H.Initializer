using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace H.Initializer
{
    public static class InitConfigureExtensions
    {
        public static void AddInit<TDbContext>(this IServiceCollection services) where TDbContext : DbContext
        {
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");

            services.ConfigureOptions(typeof(InitConfigureOptions));

            var provider = services.BuildServiceProvider();
            var scope = provider.CreateScope();
            var p = scope.ServiceProvider;
            GlobalVariable.DbContext = p.GetService<TDbContext>();
        }

        public static void UseInit(this IApplicationBuilder app, string callbackUrl)
        {
            if (string.IsNullOrWhiteSpace(callbackUrl))
                throw new ArgumentNullException("callbackUrl is empty");

            GlobalVariable.CallbackUrl = callbackUrl;
            app.UseMiddleware<InitMiddlewareExtensions>();
        }
    }
}
