using Microsoft.EntityFrameworkCore;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("product");
        
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("id").HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        
        builder.Property(p => p.Title).HasColumnName("title").IsRequired().HasMaxLength(100);
        builder.Property(p => p.Price).HasColumnName("price").IsRequired().HasPrecision(10, 2);
        builder.Property(p => p.Description).HasColumnName("description").HasMaxLength(1000);
        builder.Property(p => p.Category).HasColumnName("category").HasConversion<string>().IsRequired().HasMaxLength(20);
        builder.Property(p => p.ImageUrl).HasColumnName("image_url").HasMaxLength(500);
        builder.Property(p => p.Rate).HasColumnName("rate").IsRequired().HasPrecision(10, 2);
        builder.Property(p => p.Count).HasColumnName("count").IsRequired();
        builder.Property(p => p.CreatedBy).HasColumnName("created_by").IsRequired();
        builder.Property(p => p.CreatedAt).HasColumnName("created_at").IsRequired().HasColumnType("timestamptz").HasDefaultValueSql("now()");
        builder.Property(p => p.UpdatedAt).HasColumnName("updated_at").HasColumnType("timestamptz").IsRequired().HasDefaultValueSql("now()");
        builder.Property(p => p.DeletedAt).HasColumnName("deleted_at").HasColumnType("timestamptz").HasDefaultValueSql("null");
        
        builder.HasOne(p => p.Creator)
            .WithMany(u => u.ProductsCreated)
            .HasForeignKey(p => p.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);
    }
}