using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Infrastructure.Data.Mappings;

public class CustomerMap : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customer");

        builder.Property(c => c.Id).HasColumnName("Id").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
        builder.HasKey(c => c.Id);

        builder.Property(c => c.IdPerson).HasColumnName("Person").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
        builder.HasOne(c => c.Person).WithOne().HasForeignKey<Customer>(c => c.IdPerson).HasConstraintName("FK_Customer_Person");

        builder.Property(c => c.IdCompany).HasColumnName("Company").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
        builder.HasOne(c => c.Company).WithMany().HasForeignKey(c => c.IdCompany).HasConstraintName("FK_Customer_Company_IdCompany");

        builder.Property(c => c.Identification).HasColumnName("Identification").HasColumnType("nvarchar")
            .HasMaxLength(32).IsRequired();

        builder.Property(c => c.SecretToken).HasColumnName("SecretToken").HasColumnType("nvarchar").HasMaxLength(45)
            .IsRequired();

        builder.Property(c => c.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();
        builder.Property(c => c.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime2");
    }
}