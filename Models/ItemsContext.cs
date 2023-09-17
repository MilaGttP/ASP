using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASP.Models;

public partial class ItemsContext : DbContext
{
    public ItemsContext()
    {
    }

    public ItemsContext(DbContextOptions<ItemsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC072EA1A039");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
