using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanManager.Domain.Entities.Utils;

namespace PlanManager.Infrastructure.Data.Mappings;

public class LogActivityMap : IEntityTypeConfiguration<LogActivity>
{
    public void Configure(EntityTypeBuilder<LogActivity> builder)
    {
        builder.ToTable("LogActivity");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();

        builder.Property(x => x.User).HasColumnName("User").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();

        builder.Property(x => x.Type).HasColumnName("Type").HasColumnType("nvarchar").HasMaxLength(100).IsRequired();

        builder.Property(x => x.Action).HasColumnName("Action").HasColumnType("nvarchar").HasMaxLength(100).IsRequired();

        builder.Property(x => x.Code).HasColumnName("Code").HasColumnType("nvarchar").HasMaxLength(100).IsRequired();

        builder.Property(x => x.ObjectId).HasColumnName("ObjectId").HasColumnType("nvarchar").HasMaxLength(11);

        builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("nvarchar").HasMaxLength(150).IsRequired();

        builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime").IsRequired();

        builder.Ignore("UpdatedAt");
    }
}