﻿using Microsoft.EntityFrameworkCore;
using ShopPro.Modules.Domain.Entities;

namespace ShopPro.Modules.Persistence.Context
{
    public class ShopContext : DbContext
    {

        #region"Constructor"
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }
        #endregion

        #region"Db Sets"
        public DbSet<Employees> Employees { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>()
                .ToTable("Employees", "HR");
            modelBuilder.Entity<OrderDetails>()
                .ToTable("OrderDetails", "Sales");
        }

    }
}
