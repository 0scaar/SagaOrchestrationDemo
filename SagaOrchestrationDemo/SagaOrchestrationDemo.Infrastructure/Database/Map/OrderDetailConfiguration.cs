using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SagaOrchestrationDemo.Infrastructure.Database.Entities;

namespace SagaOrchestrationDemo.Infrastructure.Database.Map
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetail", "SagaDemo");
            builder.HasKey(od => new { od.OrderId, od.ProductId });

            builder.Property(o => o.UnitPrice)
                .IsRequired()
                .HasPrecision(8,2);

            builder.Property(o => o.Quantity)
                .IsRequired();

            builder.HasOne(o => o.Product)
                .WithMany(m => m.OrderDetails)
                .HasForeignKey(od => od.ProductId);

            builder.HasOne(o => o.Order)
                .WithMany(m => m.OrderDetails)
                .HasForeignKey(od => od.OrderId);
        }
    }
}
