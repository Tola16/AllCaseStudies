using CanteenManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.CodeDom;

namespace CanteenManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasData(
                new User() { UserId = 1, Name = "Ahmed Ali", Email = "ahmed@mail.com", PhoneNumber = "01012345678", Role = "Customer",Password="ahmed@12345" },
                new User() { UserId = 2, Name = "Sara Mohamed", Email = "sara@mail.com", PhoneNumber = "01198765432", Role = "Customer", Password = "sara@12345" },
                new User() { UserId = 3, Name = "Admin User Ali", Email = "admin@mail.com", PhoneNumber = "01099998888", Role = "Admin", Password = "admin@12345" }
            );

            modelBuilder.Entity<FoodItem>()
            .HasData(
                new FoodItem() { FoodItemId = 1, Name = "Burger", Price = 50, Category = "Meal", UserId = 3 },
                new FoodItem() { FoodItemId = 2, Name = "Juice", Price = 20, Category = "Drink", UserId = 3 }
            );

            modelBuilder.Entity<Staff>()
            .HasData(
                new Staff() { StaffId = 1, Name = "Mohamed Samy", JonTitle = "Chef", PhoneNumber = "01011112222", Status = "Available", UserId = 3 },
                new Staff() { StaffId = 2, Name = "Ali Hassan", JonTitle = "Cashier", PhoneNumber = "01133334444", Status = "Busy", UserId = 3 }
            );

            modelBuilder.Entity<Order>()
            .HasData(
                new Order() { OrderId = 1, OrderDateTime = new DateTime(2025, 3, 1), TotalPrice = 50, StaffId = 1, UserId = 1, FoodItemId = 1, Status = "Completed" },
                new Order() { OrderId = 2, OrderDateTime = new DateTime(2025, 3, 5), TotalPrice = 20, StaffId = 2, FoodItemId = 2, UserId = 2, Status = "Preparing" }
            );


            modelBuilder.Entity<Order>()
            .HasOne(u => u.User)
            .WithMany(o => o.Orders)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Staff>()
            .HasMany(s => s.Orders)
            .WithOne(o => o.Staff)
            .HasForeignKey(s => s.StaffId)
            .OnDelete(DeleteBehavior.NoAction);

        }

    }
}
