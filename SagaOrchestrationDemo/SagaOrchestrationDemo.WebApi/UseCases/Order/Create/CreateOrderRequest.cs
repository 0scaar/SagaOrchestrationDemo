using System;
using System.Collections.Generic;

namespace SagaOrchestrationDemo.WebApi.UseCases.Order.Create
{
    public class CreateOrderRequest
    {
        public string CustomerCode { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string ShipPostalCode { get; set; }
        public List<CreateOrderDetailRequest> OrderDetails { get; set; }
    }

    public class CreateOrderDetailRequest
    {
        public Guid ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
    }
}
