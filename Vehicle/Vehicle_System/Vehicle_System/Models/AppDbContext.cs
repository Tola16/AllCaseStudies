using Microsoft.EntityFrameworkCore;
using Vehicle_System.View_Model;

namespace Vehicle_System.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<MaintenanceType> MaintenanceTypes { get; set; }
        public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }
        public DbSet<Vehicle_System.View_Model.VehicleVm> VehicleVm { get; set; } = default!;
        public DbSet<Vehicle_System.View_Model.MaintenanceRecordVm> MaintenanceRecordVm { get; set; } = default!;

    }
}
