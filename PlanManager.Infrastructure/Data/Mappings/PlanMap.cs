using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanManager.Domain.Entities.Plan;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Infrastructure.Data.Mappings;

public class PlanMap : IEntityTypeConfiguration<Plan> {
	public void Configure(EntityTypeBuilder<Plan> builder) {
		builder.ToTable("Plan");

		var converter = new ValueConverter<Id, string>(v => v.Identifier, v => new Id(v));

		builder.Property(x => x.Id).HasConversion(converter).HasColumnName("Id").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasKey(x => x.Id);

		builder.Property(x => x.IdCompany).HasConversion(converter).HasColumnName("IdCompany").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasOne(x => x.Company).WithMany().HasForeignKey(x => x.IdCompany).HasConstraintName("FK_Plan_Person_PersonId").OnDelete(DeleteBehavior.Restrict)
			.IsRequired();

		builder.OwnsOne(x => x.Name, name => {
			name.Property(x => x.Value).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(30).IsRequired();
			name.HasIndex(x => x.Value).IsUnique();
		});

		builder.OwnsOne(x => x.Value, value => { value.Property(x => x.ValueWith2Digits).HasColumnType("decimal").HasColumnName("Value").IsRequired(); });
		builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();
		builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime2");
	}
}