using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Infrastructure.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User> {
	public void Configure(EntityTypeBuilder<User> builder) {
		builder.ToTable("User");


		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();

		builder.Property(x => x.IdPerson).HasColumnName("IdPerson").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasOne(x => x.Person).WithOne().HasForeignKey<User>(x => x.IdPerson).HasConstraintName("FK_User_Person").OnDelete(DeleteBehavior.Cascade);

		builder.Property(x => x.Username).HasColumnName("Username").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
		builder.Property(x => x.Password).HasColumnName("Password").HasColumnType("nvarchar").HasMaxLength(255).IsRequired();

		builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();
		builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime2");
	}
}