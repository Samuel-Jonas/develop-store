using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class RegularPersonConfiguration : IEntityTypeConfiguration<RegularPerson>
{
    public void Configure(EntityTypeBuilder<RegularPerson> builder)
    {
        builder.ToTable("regular_person");
        
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("id").HasColumnType("uuid");
        
        builder.Property(p => p.FirstName).HasColumnName("first_name").HasMaxLength(35).IsRequired();
        builder.Property(p => p.LastName).HasColumnName("last_name").HasMaxLength(35).IsRequired();
        builder.Property(p => p.City).HasColumnName("city").HasMaxLength(40);
        builder.Property(p => p.Street).HasColumnName("street").HasMaxLength(40);
        builder.Property(p => p.Number).HasColumnName("number").HasMaxLength(10);
        builder.Property(p => p.Zipcode).HasColumnName("zipcode").HasMaxLength(20);
        builder.Property(p => p.Geolocation).HasColumnName("geolocation").HasColumnType("geography (point)").IsRequired(false);
        builder.Property(p => p.CreatedAt).HasColumnName("created_at").HasColumnType("timestamptz").HasDefaultValueSql("now()").IsRequired();
        builder.Property(p => p.UpdatedAt).HasColumnName("updated_at").HasColumnType("timestamptz").IsRequired().HasDefaultValueSql("now()");
        builder.Property(p => p.DeletedAt).HasColumnName("deleted_at").HasColumnType("timestamptz").HasDefaultValueSql("null");
        
        builder.HasOne(rp => rp.Person)
            .WithOne(p => p.RegularPerson)
            .HasForeignKey<RegularPerson>(rp => rp.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}