using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shoppers_BackEnd_Final.Models;
using Shoppers_BackEnd_Final.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer(@"Server=DESKTOP-KRMBAN0;Database=Shoppers;Trusted_Connection=True");
            });


            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequiredLength = 8;
                opt.Password.RequiredUniqueChars = 0;
                opt.Password.RequireNonAlphanumeric = false;
                opt.User.RequireUniqueEmail = false;
                opt.Lockout = new LockoutOptions { MaxFailedAccessAttempts = 3, DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2) };
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<DataContext>();

            services.AddScoped<IEmailService, EmailService>();

            services.AddSession(opt =>
           {
               opt.IdleTimeout = TimeSpan.FromMinutes(15);
           });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                   name: "areas",
                   pattern: "{area:exists}/{controller=dashboard}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

               
            });
        }
    }
}
