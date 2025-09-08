using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Infrastructure.Data.Mappings
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company");

            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdPerson).HasColumnName("Person").HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
            builder.HasOne(x => x.Person).WithOne().HasForeignKey<Company>(x => x.IdPerson)
                .HasConstraintName("FK_Company_Person_IdPerson").OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime2");
        }
    }
}
