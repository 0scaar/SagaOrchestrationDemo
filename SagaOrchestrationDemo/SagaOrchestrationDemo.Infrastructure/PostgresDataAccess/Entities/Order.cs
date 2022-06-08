using SagaOrchestrationDemo.Domain.Enums;
using System;
using System.Collections.Generic;

namespace SagaOrchestrationDemo.Infrastructure.PostgresDataAccess.Entities
{
    public class Order : Entity
    {
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string ShipPostalCode { get; set; }
        public DiscountType DiscountType { get; set; }
        public double Discount { get; set; }
        public ShippingType ShippingType { get; set; }
        public Customer Customer { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
