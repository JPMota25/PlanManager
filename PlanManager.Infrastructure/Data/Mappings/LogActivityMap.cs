using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanManager.Domain.Entities.Utils;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Infrastructure.Data.Mappings;

public class LogActivityMap : IEntityTypeConfiguration<LogActivity> {
	public void Configure(EntityTypeBuilder<LogActivity> builder) {
		builder.ToTable("LogActivity");

		var converter = new ValueConverter<Id, string>(v => v.Identifier, v => new Id(v));

		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).HasConversion(converter).HasColumnName("Id").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();

		builder.Property(x => x.User).HasConversion(converter).HasColumnName("User").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasOne(x => x.FromUser).WithMany().HasForeignKey(x => x.User).HasConstraintName("FK_LogActivity_User").OnDelete(DeleteBehavior.Cascade);

		builder.Property(x => x.Type).HasColumnName("Type").HasColumnType("nvarchar").HasMaxLength(100).IsRequired();

		builder.Property(x => x.Action).HasColumnName("Action").HasColumnType("nvarchar").HasMaxLength(100).IsRequired();

		builder.Property(x => x.Code).HasColumnName("Code").HasColumnType("nvarchar").HasMaxLength(100).IsRequired();

		builder.Property(x => x.ObjectId).HasConversion(converter).HasColumnName("ObjectId").HasColumnType("nvarchar");

		builder.OwnsOne(x => x.Description,
			description => { description.Property(x => x.Value).HasColumnName("Description").HasColumnType("nvarchar").HasMaxLength(150).IsRequired(); });

		builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime").IsRequired();
	}
}