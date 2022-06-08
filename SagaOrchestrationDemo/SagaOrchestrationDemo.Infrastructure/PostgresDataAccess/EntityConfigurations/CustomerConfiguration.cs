using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SagaOrchestrationDemo.Infrastructure.PostgresDataAccess.Entities;
using System;

namespace SagaOrchestrationDemo.Infrastructure.PostgresDataAccess.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", "SagaDemo");
            builder.HasKey(d => d.Id);

            builder.Property(c => c.Code)
                .HasMaxLength(5)
                .IsFixedLength();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(40);

            builder.HasData(
                new Customer { Id = Guid.NewGuid(), Code = "ALFKI", Name = "Alfreds F." },
                new Customer { Id = Guid.NewGuid(), Code = "ANATR", Name = "Ana Trujillo" },
                new Customer { Id = Guid.NewGuid(), Code = "ANTON", Name = "Antonio Moreno" }
                );
        }
    }
}
