using H.Initializer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using Test.Initializer.Db;

namespace Test.Initializer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=InitDb_Test;Integrated Security=True;";
            services.AddDbContext<SampleDbContext>(options => options.UseSqlServer(connString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddMvcCore();
            services.AddControllers();

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                // swagger文档配置
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Restful Api Docs",
                });
                // 接口排序
                c.OrderActionsBy(t => t.RelativePath);

                // 配置 xml 文档
                var xmlPath = Path.Combine(AppContext.BaseDirectory, "Test.Initializer.xml");
                c.IncludeXmlComments(xmlPath);
            });
            #endregion
            
            services.AddRazorPages();
            services.AddInitializer<SampleDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseInitializer("/swagger");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "H.WebApi";
                //版本控制
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "v1");
                //注入汉化脚本
                c.InjectJavascript($"/swagger_translator.js");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
