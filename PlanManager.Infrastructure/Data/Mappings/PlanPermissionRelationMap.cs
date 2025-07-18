using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanManager.Domain.Entities.Plan;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Infrastructure.Data.Mappings;

public class PlanPermissionRelationMap : IEntityTypeConfiguration<PlanPermissionRelation>{
	public void Configure(EntityTypeBuilder<PlanPermissionRelation> builder) {
		builder.ToTable("PlanPermissionRelation");

		var converter = new ValueConverter<Id, string>(v => v.Identifier, v => new Id(v));

		builder.Property(x => x.Id).HasConversion(converter).HasColumnName("Id").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasKey(x => x.Id);

		builder.Property(x=>x.IdPlan).HasConversion(converter).HasColumnName("Plan").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasOne(x => x.Plan).WithMany(x=>x.Permissions).HasForeignKey(x => x.IdPlan).HasConstraintName("FK_PlanPermissionRelation_Plan_PlanId");

		builder.Property(x=>x.IdPlanPermission).HasConversion(converter).HasColumnName("PlanPermission").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasOne(x => x.PlanPermission).WithMany(x=>x.Plans).HasForeignKey(x => x.IdPlanPermission).HasConstraintName("FK_PlanPermissionRelation_PlanPermission_PlanPermissionId");

		builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();
		builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime2");
	}
}