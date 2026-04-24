using Microsoft.EntityFrameworkCore; 
using Simple_Attendance_Tracking.Models;

namespace Simple_Attendance_Tracking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<Context>();
            builder.Services.AddScoped<IStudent, StudentRepo>();
            builder.Services.AddScoped<IAttendance, AttendanceRepo>();
            builder.Services.AddScoped<ISubject, SubjectRepo>();


            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
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