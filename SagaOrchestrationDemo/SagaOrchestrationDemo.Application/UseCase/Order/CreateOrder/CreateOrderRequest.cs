using System;
using System.Collections.Generic;

namespace SagaOrchestrationDemo.Application.UseCase.Order.CreateOrder
{
    public class CreateOrderRequest
    {
        public string CustomerCode { get; private set; }
        public string ShipAddress { get; private set; }
        public string ShipCity { get; private set; }
        public string ShipCountry { get; private set; }
        public string ShipPostalCode { get; private set; }
        public List<CreateOrderDetailRequest> OrderDetails { get; private set; }
        public Guid CustomerId { get; set; }
        public bool ExistCustomer { get; set; }
        public Guid OrderId { get; set; }

        public CreateOrderRequest(string customerCode, string shipAddress, 
            string shipCity, string shipCountry, string shipPostalCode, 
            List<CreateOrderDetailRequest> orderDetails)
        {
            CustomerCode = customerCode;
            ShipAddress = shipAddress;
            ShipCity = shipCity;
            ShipCountry = shipCountry;
            ShipPostalCode = shipPostalCode;
            OrderDetails = orderDetails;
            ExistCustomer = true;
        }
    }

    public class CreateOrderDetailRequest
    {
        public Guid ProductId { get; private set; }
        public decimal UnitPrice { get; private set; }
        public short Quantity { get; private set; }

        public CreateOrderDetailRequest(Guid productId, decimal unitPrice, short quantity)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
    }
}
