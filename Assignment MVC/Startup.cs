using Assignment_MVC.Data;
using Assignment_MVC.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Assignment_MVC
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
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
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IPersonData, PersonData>();

            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<ICityServices, CityServices>();
            services.AddTransient<ILanguageServices, LanguageServices>();
            services.AddTransient<IPersonLanguageServices, PersonLanguageServices>();
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
                endpoints.MapControllerRoute(
                    name: "Persons",
                    pattern: "{controller=Persons}/{action=Persons}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "AJAX",
                    pattern: "AJAX",
                    defaults: new {controller="AJAXPersons",action="Index"}
                    );
                endpoints.MapControllerRoute(
                    name: "Cities",
                    pattern: "{controller=Cities}/{action=Index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "Countries",
                    pattern: "{controller=Countries}/{action=Index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "Languages",
                    pattern: "{controller=Language}/{action=Index}/{id?}"
                    );
                

            });
        }
    }
}
