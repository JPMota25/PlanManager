using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Infrastructure.Data.Mappings;

public class PersonMap : IEntityTypeConfiguration<Person> {
	public void Configure(EntityTypeBuilder<Person> builder) {
		builder.ToTable("Person");


		builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Status).HasColumnName("Status").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();

		builder.Property(x => x.Document).HasColumnName("Document").HasColumnType("nvarchar").HasMaxLength(14).IsRequired();
		builder.HasIndex(x => x.Document).IsUnique();

		builder.Property(x => x.Type).HasColumnName("Type").HasColumnType("nvarchar").HasMaxLength(20).IsRequired();

		builder.Property(x => x.FirstName).HasColumnName("FirstName").HasColumnType("nvarchar").HasMaxLength(30).IsRequired();
		builder.Property(x => x.LastName).HasColumnName("LastName").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();

		builder.Property(x => x.Email).HasColumnName("EmailAddress").HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
		builder.HasIndex(x => x.Email).IsUnique();

		builder.Property(x => x.CountryCode).HasColumnName("CountryCode").HasColumnType("nvarchar").HasMaxLength(6).IsRequired();
		builder.Property(x => x.DDD).HasColumnName("DDD").HasColumnType("nvarchar").HasMaxLength(6).IsRequired();
		builder.Property(x => x.NumberWithDigit).HasColumnName("PhoneNumberWithDigit").HasColumnType("nvarchar").HasMaxLength(9).IsRequired();

		builder.Property(x => x.Country).HasColumnName("Country").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
		builder.Property(x => x.City).HasColumnName("City").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
		builder.Property(x => x.Complement).HasColumnName("Complement").HasMaxLength(150).HasColumnType("nvarchar");
		builder.Property(x => x.HasHouseNumber).HasColumnName("HasHouseNumber").HasColumnType("bit").IsRequired();
		builder.Property(x => x.HouseNumber).HasColumnName("HouseNumber").HasColumnType("nvarchar").HasMaxLength(20);
		builder.Property(x => x.Street).HasColumnName("Street").HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
		builder.Property(x => x.Neighboorhood).HasColumnName("Neighboorhood").HasColumnType("nvarchar").HasMaxLength(30).IsRequired();
		builder.Property(x => x.State).HasColumnName("State").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
		builder.Property(x => x.Zipcode).HasColumnName("Zipcode").HasColumnType("nvarchar").HasMaxLength(8).IsRequired();

		builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();
		builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime2");
	}
}