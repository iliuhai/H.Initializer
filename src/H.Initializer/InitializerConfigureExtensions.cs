using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace H.Initializer
{
    public static class InitializerConfigureExtensions
    {
        public static void AddInitializer<TDbContext>(this IServiceCollection services) where TDbContext : DbContext
        {
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");

            services.ConfigureOptions(typeof(InitializerConfigureOptions));

            var provider = services.BuildServiceProvider();
            var scope = provider.CreateScope();
            var p = scope.ServiceProvider;
            GlobalVariable.DbContext = p.GetService<TDbContext>();
        }

        public static void UseInitializer(this IApplicationBuilder app, string callbackUrl)
        {
            if (string.IsNullOrWhiteSpace(callbackUrl))
                throw new ArgumentNullException("callbackUrl is empty");

            GlobalVariable.CallbackUrl = callbackUrl;
            app.UseMiddleware<InitializerMiddlewareExtensions>();
        }
    }
}
