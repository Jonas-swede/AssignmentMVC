using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Assignment_MVC
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=About}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "feverCheck",
                    pattern: "{controller=FeverCheck}/{action=Fever}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "GuessingGame",
                    pattern: "{controller=GuessingGame}/{action=GuessingGame}/{id?}"
                    );
            });
        }
    }
}
