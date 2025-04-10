using Microsoft.EntityFrameworkCore;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class CartConfiguration :IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("cart");
        
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("id").HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        
        builder.Property(c => c.UserId).HasColumnName("user_id").IsRequired();
        builder.Property(c => c.CheckedOutAt).HasColumnName("checked_out_at").HasColumnType("timestamp").IsRequired();
        builder.Property(c => c.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp").IsRequired().HasDefaultValueSql("now()");
        builder.Property(c => c.UpdatedAt).HasColumnName("updated_at").HasColumnType("timestamp").IsRequired().HasDefaultValueSql("now()");
        builder.Property(c => c.DeletedAt).HasColumnName("deleted_at").HasColumnType("timestamp").HasDefaultValueSql("null");
        
        builder.HasMany(c => c.Items)
            .WithOne(ci => ci.Cart)
            .HasForeignKey(ci => ci.CartId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(c => c.User)
            .WithOne(u => u.Cart)
            .HasForeignKey<Cart>(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);
            
    }
}