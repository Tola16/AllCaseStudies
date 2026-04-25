using CanteenManagementSystem.Data;
using CanteenManagementSystem.Models;
using CanteenManagementSystem.Repositories.Implementaion;
using CanteenManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CanteenManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));
            builder.Services.AddScoped<IGenericRepository<User>, UserRepository>();
            builder.Services.AddScoped<IGenericRepository<Staff>, StaffRepository>();

            builder.Services.AddScoped<IGenericRepository<FoodItem>, FoodItemRepository>();
            builder.Services.AddScoped<IGenericRepository<Order>, OrderRepository>();

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
