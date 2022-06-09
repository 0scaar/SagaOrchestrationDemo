using Microsoft.EntityFrameworkCore;
using SagaOrchestrationDemo.Infrastructure.Database.Entities;
using SagaOrchestrationDemo.Infrastructure.Database.Map;
using System;
using System.Collections.Generic;

namespace SagaOrchestrationDemo.Infrastructure.Database
{
    public class Context : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("SAGA_CONN")))
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("SAGA_CONN"), npgsqlOptionsAction: options =>
                {
                    options.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), new List<string>());
                    options.MigrationsHistoryTable("_MigrationHistory", "SagaDemo");
                });
            }
            else
            {
                optionsBuilder.UseInMemoryDatabase("SagaInMemory");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
