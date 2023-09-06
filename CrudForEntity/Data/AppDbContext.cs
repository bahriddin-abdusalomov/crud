
using EntityCRUD.Models.Staffs;
using EntityCRUD.Models.Travels;
using EntityCRUD.Models.Vehicles;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace EntityCRUD.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Travel> Travels { get; set; }
}
