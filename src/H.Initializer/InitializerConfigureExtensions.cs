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

        /// <summary>
        /// 启动初始化中间件
        /// </summary>
        /// <param name="app"></param>
        /// <param name="callbackUrl">初始化完成后重定向地址，默认根目录</param>
        public static void UseInitializer(this IApplicationBuilder app, string callbackUrl = "/")
        {
            if (string.IsNullOrWhiteSpace(callbackUrl))
                callbackUrl = "/";

            GlobalVariable.CallbackUrl = callbackUrl;
            app.UseMiddleware<InitializerMiddlewareExtensions>();
        }
    }
}
