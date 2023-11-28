using AutoMapper;
using BresentationLogicLayer.Interfaces;
using BresentationLogicLayer.Reposatiry;
using DataAccessLayer.DBContext;
//using DataAccessLayer.Migrations;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.PL.Helper;

namespace ToDoList.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Builder = WebApplication.CreateBuilder(args);
            Builder.Services.AddControllersWithViews();
            Builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer (Builder.Configuration.GetConnectionString("Default"));
            });
            Builder.Services.AddScoped<IUnitOfWork, IUnitOfWorkClass>();
            Builder.Services.AddAutoMapper(a => a.AddProfile(new Mapperr()));
            Builder.Services.AddAutoMapper(a => a.AddProfile(new UserProfile()));
            Builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
           .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            Builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);

            var app = Builder.Build();
            if (app.Environment.IsDevelopment())
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

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Register}/{id?}");
            });
            app.Run();
        }

     
    }
}
