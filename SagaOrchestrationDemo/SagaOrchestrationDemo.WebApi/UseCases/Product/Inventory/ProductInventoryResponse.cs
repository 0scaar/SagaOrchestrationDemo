using System.Collections.Generic;

namespace SagaOrchestrationDemo.WebApi.UseCases.Product.Inventory
{
    public class ProductInventoryResponse
    {
        public List<ProductResponse> Products { get; private set; }

        public ProductInventoryResponse(List<ProductResponse> products)
        {
            Products = products;
        }
    }

    public class ProductResponse
    {
        public string Name { get; private set; }
        public short Quantity { get; private set; }

        public ProductResponse(string name, short quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
