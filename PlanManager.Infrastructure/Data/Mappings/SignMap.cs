using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanManager.Domain.Entities.PlanManager;

namespace PlanManager.Infrastructure.Data.Mappings;

public class SignMap : IEntityTypeConfiguration<Sign> {
	public void Configure(EntityTypeBuilder<Sign> builder) {
		builder.ToTable("Sign");


		builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasKey(x => x.Id);

		builder.Property(x => x.IdCustomer).HasColumnName("Customer").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasOne(x => x.Customer).WithOne().HasForeignKey<Sign>(x => x.IdCustomer).HasConstraintName("FK_Sign_Customer")
			.OnDelete(DeleteBehavior.Restrict);

		builder.Property(x => x.IdCompany).HasColumnName("Company").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
		builder.HasOne(x => x.Company).WithOne().HasForeignKey<Sign>(x => x.IdCompany).HasConstraintName("FK_Sign_Company").OnDelete(DeleteBehavior.Restrict);

		builder.Property(x=>x.Token).HasColumnName("Token").HasColumnType("nvarchar").HasMaxLength(44);

		builder.Property(x => x.InitialTime).HasColumnType("datetime2").HasColumnName("InitialTime");

		builder.Property(x => x.Status).HasColumnName("Status").HasColumnType("nvarchar").IsRequired();

		builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();
		builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime2");
	}
}