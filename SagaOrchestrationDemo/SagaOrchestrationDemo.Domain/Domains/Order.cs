using SagaOrchestrationDemo.Domain.Enums;
using System;
using System.Collections.Generic;

namespace SagaOrchestrationDemo.Domain.Domains
{
    public class Order : Entity
    {
        public Guid CustomerId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public string ShipAddress { get; private set; }
        public string ShipCity { get; private set; }
        public string ShipCountry { get; private set; }
        public string ShipPostalCode { get; private set; }
        public DiscountType DiscountType { get; private set; }
        public double Discount { get; private set; }
        public ShippingType ShippingType { get; private set; }
        public Customer Customer { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public Order(Guid id, Guid customerId, DateTime orderDate, string shipAddress, 
            string shipCity, string shipCountry, string shipPostalCode, 
            DiscountType discountType, double discount, ShippingType shippingType)
            : base(id)
        {
            CustomerId = customerId;
            OrderDate = orderDate;
            ShipAddress = shipAddress;
            ShipCity = shipCity;
            ShipCountry = shipCountry;
            ShipPostalCode = shipPostalCode;
            DiscountType = discountType;
            Discount = discount;
            ShippingType = shippingType;
        }
    }
}
