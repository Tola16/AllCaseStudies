using CinemaSystem.Models;
using Microsoft.EntityFrameworkCore;
using CinemaSystem.Repos.Interfaces;
using CinemaSystem.Repos.implement;
namespace CinemaSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("con")));
            builder.Services.AddScoped<IGenericRepo<User>, UserRepo>();
            builder.Services.AddScoped<IGenericRepo<ShowTime>, ShowTimeRepo>();
            builder.Services.AddScoped<IGenericRepo<Movie>, MovieRepo>();
            builder.Services.AddScoped<IGenericRepo<Hall>, HallRepo>();

            builder.Services.AddScoped<IMovieRepo, MovieRepo>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }


}
