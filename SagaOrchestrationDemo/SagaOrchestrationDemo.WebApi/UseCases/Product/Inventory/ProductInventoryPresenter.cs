using Microsoft.AspNetCore.Mvc;
using SagaOrchestrationDemo.Application.Boundaries.Product;
using SagaOrchestrationDemo.Application.Helpers;
using SagaOrchestrationDemo.WebApi.Helpers;
using System.Linq;

namespace SagaOrchestrationDemo.WebApi.UseCases.Product.Inventory
{
    public class ProductInventoryPresenter : Presenter, IOutputPort<InventoryBoundary>
    {
        public void Standard(InventoryBoundary output)
        {
            var request = output.Products.Select(s => new ProductResponse(s.Name, s.Quantity)).ToList();

            ViewModel = new OkObjectResult(request);
        }
    }
}
