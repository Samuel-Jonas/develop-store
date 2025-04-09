using Microsoft.EntityFrameworkCore;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable("cart_item");
        
        builder.HasKey(ci => ci.Id);
        builder.Property(ci => ci.Id).HasColumnName("id").HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        
        builder.Property(ci => ci.Quantity).HasColumnName("quantity").IsRequired();
        builder.Property(ci => ci.PriceAtAddition).HasColumnName("price_at_addition").IsRequired().HasPrecision(10, 2);
        builder.Property(ci => ci.CreatedAt).HasColumnName("created_at").IsRequired().HasColumnType("datetime").HasDefaultValueSql("now()");
        builder.Property(ci => ci.UpdatedAt).HasColumnName("updated_at").HasColumnType("datetime");
        builder.Property(ci => ci.CartId).HasColumnName("cart_id").HasColumnType("uuid");
        builder.Property(ci => ci.ProductId).HasColumnName("product_id").HasColumnType("uuid");

        builder.HasOne(ci => ci.Cart)
            .WithMany(c => c.Items)
            .HasForeignKey(ci => ci.CartId);
        
        builder.HasOne(ci => ci.Product)
            .WithMany()
            .HasForeignKey(ci => ci.ProductId);
    }
}