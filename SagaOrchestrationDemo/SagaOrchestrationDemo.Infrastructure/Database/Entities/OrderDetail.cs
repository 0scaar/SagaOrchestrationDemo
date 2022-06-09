using System;

namespace SagaOrchestrationDemo.Infrastructure.Database.Entities
{
    public class OrderDetail
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
