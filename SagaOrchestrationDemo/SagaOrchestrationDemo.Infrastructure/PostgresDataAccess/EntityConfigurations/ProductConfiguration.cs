using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SagaOrchestrationDemo.Infrastructure.PostgresDataAccess.Entities;
using System;

namespace SagaOrchestrationDemo.Infrastructure.PostgresDataAccess.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", "SagaDemo");
            builder.HasKey(d => d.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(p => p.Quantity)
                .IsRequired();

            builder.HasData(
                new Product { Id = Guid.NewGuid(), Name = "Chai", Quantity = 10 },
                new Product { Id = Guid.NewGuid(), Name = "Chang", Quantity = 30 },
                new Product { Id = Guid.NewGuid(), Name = "Aniseed Syrup", Quantity = 15 }
                );
        }
    }
}
