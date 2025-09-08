using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanManager.Domain.Entities.UserPermission;

namespace PlanManager.Infrastructure.Data.Mappings
{
    public class PermissionMap : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();

            builder.Property(x => x.IdGroupPermission).HasColumnName("GroupPermission").HasColumnType("nvarchar")
                .HasMaxLength(11).IsRequired();
            builder.HasOne(x => x.GroupPermission).WithMany().HasForeignKey(x => x.IdGroupPermission)
                .HasConstraintName("FK_Permission_GroupPermission_IdGroupPermission").OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.KeyPermission).HasColumnName("KeyPermission").HasColumnType("nvarchar")
                .HasMaxLength(50).IsRequired();

            builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime2");
        }
    }
}
