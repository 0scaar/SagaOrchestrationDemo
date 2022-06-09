using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SagaOrchestrationDemo.Infrastructure.Database.Entities;

namespace SagaOrchestrationDemo.Infrastructure.Database.Map
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order", "SagaDemo");
            builder.HasKey(d => d.Id);

            builder.Property(o => o.CustomerId)
                .IsRequired();

            builder.Property(o => o.OrderDate)
                .IsRequired();

            builder.Property(o => o.ShipAddress)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(o => o.ShipCity)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(o => o.ShipCountry)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(o => o.ShipPostalCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasOne(o => o.Customer)
                .WithMany(m => m.Orders)
                .HasForeignKey(o => o.CustomerId);
        }
    }
}
