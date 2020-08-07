using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Proj_3_Github_Test.datamodels;
using Proj_3_Github_Test.Repository;

namespace Proj_3_Github_Test
{
    public class Startup
    {
        //private const string ConnectionString = "Server=MandarPC;Database=MandarDB;user id=mandar;password=pass@1234; Integrated Security=True;";
        private const string ConnectionString = "Server=mandardbserver.database.windows.net;Database=CoreGitHubDB;user id=dbadmin;password=pass@1234; Integrated Security=False;";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<MandarDBContext>(
                options => options.UseSqlServer(ConnectionString)
            );

#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
            services.AddScoped<BookRepository, BookRepository>();
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
