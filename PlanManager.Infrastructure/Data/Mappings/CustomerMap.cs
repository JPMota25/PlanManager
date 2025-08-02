using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Infrastructure.Data.Mappings;

public class CustomerMap : IEntityTypeConfiguration<Customer> {
	public void Configure(EntityTypeBuilder<Customer> builder) {
		builder.ToTable("Customer");

		builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasKey(x => x.Id);

		builder.Property(x => x.IdPerson).HasColumnName("Person").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasOne(x => x.Person).WithOne().HasForeignKey<Customer>(x => x.IdPerson).HasConstraintName("FK_Customer_Person");

		builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();
		builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime2");
	}
}