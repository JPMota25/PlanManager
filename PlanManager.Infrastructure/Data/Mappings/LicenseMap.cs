using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanManager.Domain.Entities.Plan;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Infrastructure.Data.Mappings;

public class LicenseMap : IEntityTypeConfiguration<License> {
	public void Configure(EntityTypeBuilder<License> builder) {
		builder.ToTable("License");

		var converter = new ValueConverter<Id, string>(v => v.Identifier, v => new Id(v));

		builder.Property(x => x.Id).HasConversion(converter).HasColumnName("Id").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasKey(x => x.Id);

		builder.Property(x => x.IdSign).HasConversion(converter).HasColumnName("Sign").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasOne(x => x.Sign).WithMany().HasForeignKey(x => x.IdSign).HasConstraintName("FK_License_Sign");

		builder.Property(x => x.IdPlan).HasConversion(converter).HasColumnName("Plan").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasOne(x => x.Plan).WithMany().HasForeignKey(x => x.IdPlan).HasConstraintName("FK_License_Plan");

		builder.Property(x => x.Status).HasColumnName("Status").HasColumnType("nvarchar").IsRequired();

		builder.Property(x => x.Type).HasColumnName("Type").HasColumnType("nvarchar").IsRequired();

		builder.OwnsOne(x => x.Value, value => { value.Property(x => x.ValueWith2Digits).HasColumnName("Value").HasColumnType("decimal").IsRequired(); });

		builder.OwnsOne(x => x.ExpireDate, expireDate => {
			expireDate.Property(x => x.Expire).HasColumnName("ExpireDate").HasColumnType("date").IsRequired();
			expireDate.Property(x => x.ProlongationInDays).HasColumnName("ProlongationInDays").HasColumnType("int").IsRequired();
		});

		builder.Property(x => x.LastDaySynced).HasColumnName("LastDaySynced").HasColumnType("date");

		builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();
		builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime2");
	}
}