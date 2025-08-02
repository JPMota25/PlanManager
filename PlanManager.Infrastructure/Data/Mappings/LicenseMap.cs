using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanManager.Domain.Entities.PlanManager;

namespace PlanManager.Infrastructure.Data.Mappings;

public class LicenseMap : IEntityTypeConfiguration<License> {
	public void Configure(EntityTypeBuilder<License> builder) {
		builder.ToTable("License");

		builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasKey(x => x.Id);

		builder.Property(x => x.IdSign).HasColumnName("Sign").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasOne(x => x.Sign).WithMany().HasForeignKey(x => x.IdSign).HasConstraintName("FK_License_Sign");

		builder.Property(x => x.IdPlan).HasColumnName("Plan").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasOne(x => x.Plan).WithMany().HasForeignKey(x => x.IdPlan).HasConstraintName("FK_License_Plan");

		builder.Property(x => x.Status).HasColumnName("Status").HasColumnType("nvarchar").IsRequired();

		builder.Property(x => x.Type).HasColumnName("Type").HasColumnType("nvarchar").IsRequired();

		builder.Property(x => x.Value).HasColumnName("Value").HasColumnType("decimal").IsRequired();

		builder.Property(x => x.Expire).HasColumnName("ExpireDate").HasColumnType("date").IsRequired();
		builder.Property(x => x.ProlongationInDays).HasColumnName("ProlongationInDays").HasColumnType("int").IsRequired();

		builder.Property(x => x.LastDaySynced).HasColumnName("LastDaySynced").HasColumnType("date");

		builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();
		builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime2");
	}
}