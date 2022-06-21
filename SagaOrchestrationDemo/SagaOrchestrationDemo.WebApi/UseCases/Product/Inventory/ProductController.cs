using Microsoft.AspNetCore.Mvc;
using SagaOrchestrationDemo.Application.UseCase.Product.UpdateInventory;
using System.Linq;

namespace SagaOrchestrationDemo.WebApi.UseCases.Product.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUpdateInventoryUseCase useCase;
        private readonly ProductInventoryPresenter presenter;

        public ProductController(IUpdateInventoryUseCase useCase, ProductInventoryPresenter presenter)
        {
            this.useCase = useCase;
            this.presenter = presenter;
        }

        [HttpPost()]
        [ProducesResponseType(typeof(ProductInventoryResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [Route("ProductInventory")]
        public IActionResult ProductInventory([FromBody] ProductInventoryRequest input)
        {
            var products = input.Products.Select(s => new ProductInventory(s.ProductId, s.Quantity)).ToList();
            var request = new UpdateInventoryRequest(products);

            useCase.Execute(request);

            return presenter.ViewModel;
        }
    }
}
