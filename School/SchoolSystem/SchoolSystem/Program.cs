

using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SchoolSystem.Models;
using SchoolSystem.Repos.Implementations;
using SchoolSystem.Repos.Interface;

namespace SchoolSystem
{
    public class Program
    {
        static void Main ( string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>
                (a=>a.UseSqlServer(builder.Configuration.GetConnectionString("con")));
            // Add services to the container.

            builder.Services.AddScoped<IGenericRepo<Student>, StudentRepo>();
            builder.Services.AddScoped<IGenericRepo<Course>, CourseRepo>();
            builder.Services.AddScoped<IGenericRepo<Enrollment>, EnrollmentReop>();
          
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();


            app.Run();


        }
    }
}

