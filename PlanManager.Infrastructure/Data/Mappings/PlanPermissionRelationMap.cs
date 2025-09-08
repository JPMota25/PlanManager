using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanManager.Domain.Entities.PlanManager;

namespace PlanManager.Infrastructure.Data.Mappings;

public class PlanPermissionRelationMap : IEntityTypeConfiguration<PlanPermissionRelation>
{
    public void Configure(EntityTypeBuilder<PlanPermissionRelation> builder)
    {
        builder.ToTable("PlanPermissionRelation");


        builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
        builder.HasKey(x => x.Id);

        builder.Property(x => x.IdPlan).HasColumnName("Plan").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
        builder.HasOne(x => x.Plan).WithMany(x => x.Permissions).HasForeignKey(x => x.IdPlan).HasConstraintName("FK_PlanPermissionRelation_Plan_PlanId");

        builder.Property(x => x.IdPlanPermission).HasColumnName("PlanPermission").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
        builder.HasOne(x => x.PlanPermission).WithMany(x => x.Plans).HasForeignKey(x => x.IdPlanPermission)
            .HasConstraintName("FK_PlanPermissionRelation_PlanPermission_PlanPermissionId");

        builder.Property(c => c.IdCompany).HasColumnName("Company").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
        builder.HasOne(c => c.Company).WithOne().HasForeignKey<PlanPermissionRelation>(c => c.IdCompany).HasConstraintName("FK_PlanPermissionRelation_Company_IdCompany").OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();
        builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime2");
    }
}