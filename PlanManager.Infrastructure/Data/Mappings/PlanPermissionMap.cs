using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanManager.Domain.Entities.PlanManager;

namespace PlanManager.Infrastructure.Data.Mappings;

public class PlanPermissionMap : IEntityTypeConfiguration<PlanPermission> {
	public void Configure(EntityTypeBuilder<PlanPermission> builder) {
		builder.ToTable("PlanPermission");


		builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(30).IsRequired();

		builder.Property(x => x.Code).HasColumnName("Code").HasColumnType("nvarchar").HasMaxLength(28).IsRequired();
		builder.HasIndex(x => x.Code).IsUnique();

		builder.Property(x => x.IdCompany).HasColumnName("Company").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasOne(x => x.Company).WithMany().HasForeignKey(x => x.IdCompany).HasConstraintName("FK_PlanPermission_Company");

		builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();
		builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime2");
	}
}