using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("person");
        
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("id").HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(p => p.UserId).HasColumnName("user_id").HasColumnType("uuid");
        builder.Property(p => p.Type).HasColumnName("type").HasConversion<string>().IsRequired().HasMaxLength(20);
        builder.Property(p => p.CreatedAt).HasColumnName("created_at").HasColumnType("timestamptz").IsRequired().HasDefaultValueSql("now()");
        builder.Property(p => p.UpdatedAt).HasColumnName("updated_at").HasColumnType("timestamptz").IsRequired().HasDefaultValueSql("now()");
        builder.Property(p => p.DeletedAt).HasColumnName("deleted_at").HasColumnType("timestamptz").HasDefaultValueSql("null");
        
        builder.HasOne(p => p.User)
            .WithOne(u => u.Person)
            .HasForeignKey<Person>(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.RegularPerson)
            .WithOne(rp => rp.Person)
            .HasForeignKey<RegularPerson>(rp => rp.Id);
    }
}