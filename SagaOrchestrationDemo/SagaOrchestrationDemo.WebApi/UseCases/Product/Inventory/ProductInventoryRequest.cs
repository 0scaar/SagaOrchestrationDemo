using System;
using System.Collections.Generic;

namespace SagaOrchestrationDemo.WebApi.UseCases.Product.Inventory
{
    public class ProductInventoryRequest
    {
        public List<ProductRequest> Products { get; set; }
    }

    public class ProductRequest
    {
        public Guid ProductId { get; set; }
        public short Quantity { get; set; }
    }
}
