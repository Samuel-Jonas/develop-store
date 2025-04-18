﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("id").HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Username).HasColumnName("username").IsRequired().HasMaxLength(50);
        builder.Property(u => u.Password).HasColumnName("password").IsRequired().HasMaxLength(100);
        builder.Property(u => u.Email).HasColumnName("email").IsRequired().HasMaxLength(100);
        builder.Property(u => u.Phone).HasColumnName("phone").HasMaxLength(20);

        builder.Property(u => u.Status)
            .IsRequired()
            .HasColumnName("status")
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(u => u.Role)
            .IsRequired()
            .HasColumnName("role")
            .HasConversion<string>()
            .HasMaxLength(20);
        
        builder.Property(u => u.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at")
            .HasColumnType("timestamptz")
            .HasDefaultValueSql("now()");
        
        builder.Property(u => u.UpdatedAt).HasColumnName("updated_at").HasColumnType("timestamptz").IsRequired().HasDefaultValueSql("now()");
        builder.Property(u => u.DeletedAt).HasColumnName("deleted_at").HasColumnType("timestamptz").HasDefaultValueSql("null");

    }
}
