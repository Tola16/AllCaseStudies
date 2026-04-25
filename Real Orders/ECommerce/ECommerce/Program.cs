using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Repositories.Implementations;
using ECommerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));
            builder.Services.AddScoped<IGenericRepository<Product>, ProductRepository>();
            builder.Services.AddScoped<IGenericRepository<Customer>, CustomerRepository>();
            builder.Services.AddScoped<IGenericRepository<Order>, OrderRepository>();
            builder.Services.AddScoped<IGenericRepository<OrderItem>, OrderItemRepository>();

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
