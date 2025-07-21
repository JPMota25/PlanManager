using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Infrastructure.Data.Mappings;

public class CustomerMap : IEntityTypeConfiguration<Customer> {
	public void Configure(EntityTypeBuilder<Customer> builder) {
		builder.ToTable("Customer");

		var converter = new ValueConverter<Id, string>(v => v.Identifier, v => new Id(v));

		builder.Property(x => x.Id).HasConversion(converter).HasColumnName("Id").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasKey(x => x.Id);

		builder.Property(x => x.IdPerson).HasConversion(converter).HasColumnName("Person").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasOne(x => x.Person).WithOne().HasForeignKey<Customer>(x => x.IdPerson).HasConstraintName("FK_Customer_Person");

		builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();
		builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime2");
	}
}