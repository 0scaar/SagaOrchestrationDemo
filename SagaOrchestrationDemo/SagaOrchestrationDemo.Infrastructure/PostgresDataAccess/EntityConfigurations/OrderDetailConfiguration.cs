using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SagaOrchestrationDemo.Infrastructure.PostgresDataAccess.Entities;

namespace SagaOrchestrationDemo.Infrastructure.PostgresDataAccess.EntityConfigurations
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

            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(od => od.ProductId);

            builder.HasOne<Order>()
                .WithMany()
                .HasForeignKey(od => od.OrderId);
        }
    }
}
