using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Vehicle_System.Implementation;
using Vehicle_System.Interface;
using Vehicle_System.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));


builder.Services.AddScoped<IGenericRepo<User>, UserRepo>();
builder.Services.AddScoped<IGenericRepo<Vehicle>, VehicleRepo>();
builder.Services.AddScoped<IGenericRepo<MaintenanceRecord>, MaintenanceRecordRepo>();
builder.Services.AddScoped<IGenericRepo<MaintenanceType>, MaintenanceTypeRepo>();



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
