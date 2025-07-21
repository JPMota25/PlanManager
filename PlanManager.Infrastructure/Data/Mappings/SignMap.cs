using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanManager.Domain.Entities.Plan;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Infrastructure.Data.Mappings;

public class SignMap : IEntityTypeConfiguration<Sign> {
	public void Configure(EntityTypeBuilder<Sign> builder) {
		builder.ToTable("Sign");

		var converter = new ValueConverter<Id, string>(v => v.Identifier, v => new Id(v));

		builder.Property(x => x.Id).HasConversion(converter).HasColumnName("Id").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasKey(x => x.Id);

		builder.Property(x => x.IdCustomer).HasConversion(converter).HasColumnName("Customer").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasOne(x => x.Customer).WithOne().HasForeignKey<Sign>(x => x.IdCustomer).HasConstraintName("FK_Sign_Customer")
			.OnDelete(DeleteBehavior.Restrict);

		builder.Property(x => x.IdCompany).HasConversion(converter).HasColumnName("Company").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasOne(x => x.Company).WithOne().HasForeignKey<Sign>(x => x.IdCompany).HasConstraintName("FK_Sign_Company").OnDelete(DeleteBehavior.Restrict);

		builder.Property(x => x.InitialTime).HasColumnType("datetime2").HasColumnName("InitialTime");

		builder.Property(x => x.Status).HasColumnName("Status").HasColumnType("nvarchar").IsRequired();

		builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();
		builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime2");
	}
}