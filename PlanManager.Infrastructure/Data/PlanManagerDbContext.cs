using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using PlanManager.Domain.Entities.Plan;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Entities.Utils;
using PlanManager.Infrastructure.Data.Mappings;

namespace PlanManager.Infrastructure.Data;

public class PlanManagerDbContext : DbContext {
	public PlanManagerDbContext(DbContextOptions<PlanManagerDbContext> options) : base(options) { }

	public DbSet<Person> Persons { get; set; }
	public DbSet<User> Users { get; set; }
	public DbSet<Plan> Plans { get; set; }
	public DbSet<PlanPermission> PlanPermissions { get; set; }
	public DbSet<PlanPermissionRelation> PlanPermissionRelations { get; set; }

	public DbSet<LogActivity> LogActivities { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		modelBuilder.Ignore<Notification>();

		modelBuilder.ApplyConfiguration(new PersonMap());
		modelBuilder.ApplyConfiguration(new UserMap());
		modelBuilder.ApplyConfiguration(new LogActivityMap());
		modelBuilder.ApplyConfiguration(new PlanMap());
		modelBuilder.ApplyConfiguration(new PlanPermissionMap());
		modelBuilder.ApplyConfiguration(new PlanPermissionRelationMap());


		modelBuilder.Entity<Person>().Property(x => x.Status).HasConversion<string>();

		modelBuilder.Entity<LogActivity>().Property(e => e.Type).HasConversion<string>();
		modelBuilder.Entity<LogActivity>().Property(e => e.Action).HasConversion<string>();
		modelBuilder.Entity<LogActivity>().Property(e => e.Code).HasConversion<string>();


	}
}