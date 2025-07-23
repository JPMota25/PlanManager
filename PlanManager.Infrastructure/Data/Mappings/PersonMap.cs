using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Infrastructure.Data.Mappings;

public class PersonMap : IEntityTypeConfiguration<Person> {
	public void Configure(EntityTypeBuilder<Person> builder) {
		builder.ToTable("Person");

		var converter = new ValueConverter<Id, string>(v => v.Identifier, v => new Id(v));

		builder.Property(x => x.Id).HasConversion(converter).HasColumnName("Id").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Status).HasColumnName("Status").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();

		builder.OwnsOne(x => x.Document, document => {
			document.Property(x => x.Identification).HasColumnName("Document").HasColumnType("nvarchar").HasMaxLength(14).IsRequired();
			document.HasIndex(x => x.Identification).IsUnique();
			document.Property(x => x.Type).HasColumnName("Type").HasColumnType("nvarchar").HasMaxLength(20).IsRequired();
		});

		builder.OwnsOne(x => x.FullName, fullName => {
			fullName.Property(x => x.FirstName).HasColumnName("FirstName").HasColumnType("nvarchar").HasMaxLength(30).IsRequired();
			fullName.Property(x => x.LastName).HasColumnName("LastName").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
		});

		builder.OwnsOne(x => x.Email, email => {
			email.Property(x => x.EmailAddress).HasColumnName("EmailAddress").HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
			email.HasIndex(x => x.EmailAddress).IsUnique();
		});

		builder.OwnsOne(x => x.Phone, phone => {
			phone.Property(x => x.CountryCode).HasColumnName("CountryCode").HasColumnType("nvarchar").HasMaxLength(6).IsRequired();
			phone.Property(x => x.DDD).HasColumnName("DDD").HasColumnType("nvarchar").HasMaxLength(6).IsRequired();
			phone.Property(x => x.NumberWithDigit).HasColumnName("PhoneNumberWithDigit").HasColumnType("nvarchar").HasMaxLength(9).IsRequired();
		});

		builder.OwnsOne(x => x.Address, address => {
			address.Property(x => x.Country).HasColumnName("Country").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
			address.Property(x => x.City).HasColumnName("City").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
			address.Property(x => x.Complement).HasColumnName("Complement").HasMaxLength(150).HasColumnType("nvarchar");
			address.Property(x => x.HasHouseNumber).HasColumnName("HasHouseNumber").HasColumnType("bit").IsRequired();
			address.Property(x => x.HouseNumber).HasColumnName("HouseNumber").HasColumnType("nvarchar").HasMaxLength(20);
			address.Property(x => x.Street).HasColumnName("Street").HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
			address.Property(x => x.Neighboorhood).HasColumnName("Neighboorhood").HasColumnType("nvarchar").HasMaxLength(30).IsRequired();
			address.Property(x => x.State).HasColumnName("State").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
			address.Property(x => x.Zipcode).HasColumnName("Zipcode").HasColumnType("nvarchar").HasMaxLength(8).IsRequired();
		});

		builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();
		builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime2");
	}
}