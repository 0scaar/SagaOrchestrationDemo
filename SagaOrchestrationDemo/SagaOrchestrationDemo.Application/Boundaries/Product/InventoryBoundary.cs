using System.Collections.Generic;
using Domain = SagaOrchestrationDemo.Domain.Domains;

namespace SagaOrchestrationDemo.Application.Boundaries.Product
{
    public class InventoryBoundary
    {
        public List<Domain::Product> Products { get; private set; }

        public InventoryBoundary(List<Domain.Domains.Product> products)
        {
            Products = products;
        }
    }
}
