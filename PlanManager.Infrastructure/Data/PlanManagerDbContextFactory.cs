using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PlanManager.Infrastructure.Data;

public class PlanManagerDbContextFactory : IDesignTimeDbContextFactory<PlanManagerDbContext>
{
    public PlanManagerDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

        var connectionString = config.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<PlanManagerDbContext>();
        optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("PlanManager.Infrastructure"));

        return new PlanManagerDbContext(optionsBuilder.Options);
    }
}