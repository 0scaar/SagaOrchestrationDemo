using System;

namespace SagaOrchestrationDemo.Domain.Domains
{
    public class OrderDetail
    {
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public decimal UnitPrice { get; private set; }
        public short Quantity { get; private set; }
        public Order Order { get; private set; }
        public Product Product { get; private set; }

        public OrderDetail(Guid orderId, Guid productId, decimal unitPrice, short quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public OrderDetail(Guid orderId, Guid productId, decimal unitPrice, short quantity, Order order, Product product) 
            : this(orderId, productId, unitPrice, quantity)
        {
            Order = order;
            Product = product;
        }
    }
}
