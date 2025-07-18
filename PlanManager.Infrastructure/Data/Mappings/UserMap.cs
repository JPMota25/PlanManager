using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Infrastructure.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User> {
	public void Configure(EntityTypeBuilder<User> builder) {
		builder.ToTable("User");

		var converter = new ValueConverter<Id, string>(v => v.Identifier, v => new Id(v));

		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).HasConversion(converter).HasColumnName("Id").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();

		builder.Property(x => x.IdPerson).HasConversion(converter).HasColumnName("IdPerson").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasIndex(x => x.IdPerson).IsUnique();
		builder.HasOne(x => x.Person).WithOne().HasForeignKey<User>(x => x.IdPerson).HasConstraintName("FK_User_Person").OnDelete(DeleteBehavior.Cascade);

		builder.OwnsOne(x => x.Username,
			username => { username.Property(x => x.Value).HasColumnName("Username").HasColumnType("nvarchar").HasMaxLength(50).IsRequired(); });

		builder.Property(x => x.Password).HasColumnName("Password").HasColumnType("nvarchar").IsRequired();
		builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();
		builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime2");
	}
}