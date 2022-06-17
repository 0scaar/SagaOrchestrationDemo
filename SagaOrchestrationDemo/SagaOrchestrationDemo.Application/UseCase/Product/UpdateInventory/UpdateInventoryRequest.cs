using System;
using System.Collections.Generic;
using Domain = SagaOrchestrationDemo.Domain.Domains;

namespace SagaOrchestrationDemo.Application.UseCase.Product.UpdateInventory
{
    public class UpdateInventoryRequest
    {
        public List<ProductInventory> ProductInventories { get; private set; }
        public List<Domain::Product> Products { get; set; }
        public bool ExistAllProduct { get; set; } = true;
        public bool ValidateUpdate { get; set; } = true;
        public List<Domain::Product> ProductsOutput { get; set; }

        public UpdateInventoryRequest(List<ProductInventory> productInventories)
        {
            ProductInventories = productInventories;
            Products = new List<Domain::Product>();
        }
    }

    public class ProductInventory
    {
        public Guid ProductId { get; private set; }
        public short Quantity { get; private set; }

        public ProductInventory(Guid productId, short quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
