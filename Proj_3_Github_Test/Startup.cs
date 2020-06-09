using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Proj_3_Github_Test
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            //app.Use(async (context,next) =>
            //{
            //    await context.Response.WriteAsync("My first Middleware");

            //    await next();

            //    await context.Response.WriteAsync("My first Middleware - Response");
            //});

            //app.Use(async(context,next) =>
            //    {
            //        await context.Response.WriteAsync("</br>My 2nd Middleware");
            //    }
            //);

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();

                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/Mandar", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World from Mandar!");
            //    });
            //});
        }
    }
}
