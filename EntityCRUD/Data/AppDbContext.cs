
using EntityCRUD.Models.Staffs;
using EntityCRUD.Models.Travels;
using EntityCRUD.Models.Vehicles;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace EntityCRUD.Data;

public class AppDbContext : DbContext
{
    private readonly string connectionString = "Host = localhost; User Id = postgres; Password = salom; " +
                                                                    "Port = 5432; Database = entityCrud-db;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(connectionString);
    }
        
    public DbSet<User> Users { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Travel> Travels { get; set; }
}
