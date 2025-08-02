using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanManager.Domain.Entities.PlanManager;

namespace PlanManager.Infrastructure.Data.Mappings;

public class PlanMap : IEntityTypeConfiguration<Plan> {
	public void Configure(EntityTypeBuilder<Plan> builder) {
		builder.ToTable("Plan");


		builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasKey(x => x.Id);

		builder.Property(x => x.IdCompany).HasColumnName("IdCompany").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasOne(x => x.Company).WithMany().HasForeignKey(x => x.IdCompany).HasConstraintName("FK_Plan_Person_PersonId").OnDelete(DeleteBehavior.Restrict)
			.IsRequired();

		builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(30).IsRequired();
		builder.HasIndex(x => x.Name).IsUnique();

		builder.Property(x => x.Value).HasColumnType("decimal").HasColumnName("Value").IsRequired();

		builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();
		builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime2");
	}
}