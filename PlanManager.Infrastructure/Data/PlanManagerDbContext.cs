using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Entities.UserPermission;
using PlanManager.Domain.Entities.Utils;
using PlanManager.Infrastructure.Data.Mappings;

namespace PlanManager.Infrastructure.Data;

public class PlanManagerDbContext : DbContext
{
    public PlanManagerDbContext(DbContextOptions<PlanManagerDbContext> options) : base(options) { }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Plan> Plans { get; set; }
    public DbSet<PlanPermission> PlanPermissions { get; set; }
    public DbSet<PlanPermissionRelation> PlanPermissionRelations { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Sign> Signs { get; set; }
    public DbSet<License> Licenses { get; set; }

    public DbSet<LogActivity> LogActivities { get; set; }

    public DbSet<GroupPermission> GroupPermissions { get; set; }
    public DbSet<Permission> Permissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Notification>();

        modelBuilder.ApplyConfiguration(new PersonMap());
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new LogActivityMap());
        modelBuilder.ApplyConfiguration(new PlanMap());
        modelBuilder.ApplyConfiguration(new PlanPermissionMap());
        modelBuilder.ApplyConfiguration(new PlanPermissionRelationMap());
        modelBuilder.ApplyConfiguration(new CustomerMap());
        modelBuilder.ApplyConfiguration(new SignMap());
        modelBuilder.ApplyConfiguration(new LicenseMap());
        modelBuilder.ApplyConfiguration(new CompanyMap());
        modelBuilder.ApplyConfiguration(new GroupPermissionMap());
        modelBuilder.ApplyConfiguration(new PermissionMap());

        modelBuilder.Entity<Person>().Property(x => x.Status).HasConversion<string>();

        modelBuilder.Entity<LogActivity>().Property(e => e.Type).HasConversion<string>();
        modelBuilder.Entity<LogActivity>().Property(e => e.Action).HasConversion<string>();
        modelBuilder.Entity<LogActivity>().Property(e => e.Code).HasConversion<string>();

        modelBuilder.Entity<Sign>().Property(e => e.Status).HasConversion<string>();

        modelBuilder.Entity<GroupPermission>().Property(e => e.IsActive).HasConversion<string>();

        modelBuilder.Entity<License>().Property(e => e.Status).HasConversion<string>();
        modelBuilder.Entity<License>().Property(e => e.Type).HasConversion<string>();
    }
}