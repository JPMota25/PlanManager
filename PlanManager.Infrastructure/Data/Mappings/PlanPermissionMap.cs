using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Infrastructure.Data.Mappings;

public class PlanPermissionMap : IEntityTypeConfiguration<PlanPermission> {
	public void Configure(EntityTypeBuilder<PlanPermission> builder) {
		builder.ToTable("PlanPermission");

		var converter = new ValueConverter<Id, string>(v => v.Identifier, v => new Id(v));

		builder.Property(x => x.Id).HasConversion(converter).HasColumnName("Id").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasKey(x => x.Id);

		builder.OwnsOne(x => x.Name, name => { name.Property(x => x.Value).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(30).IsRequired(); });

		builder.OwnsOne(x => x.Code, code => {
			code.Property(x => x.Code).HasColumnName("Code").HasColumnType("nvarchar").HasMaxLength(28).IsRequired();
			code.HasIndex(x => x.Code).IsUnique();
		});

		builder.Property(x => x.IdCompany).HasConversion(converter).HasColumnName("IdCompany").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasOne(x => x.Company).WithMany().HasForeignKey(x => x.IdCompany).HasConstraintName("FK_PlanPermission_Company");

		builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();
		builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime2");
	}
}