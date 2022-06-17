using Microsoft.AspNetCore.Mvc;
using SagaOrchestrationDemo.Application.UseCase.ProductByQty;
using System.Collections.Generic;

namespace SagaOrchestrationDemo.WebApi.UseCases.Product.ProductsByQty
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductByQtyUseCase useCase;
        private readonly ProductsByQtyPresenter presenter;

        public ProductController(IProductByQtyUseCase useCase, ProductsByQtyPresenter presenter)
        {
            this.useCase = useCase;
            this.presenter = presenter;
        }

        [HttpPost()]
        [ProducesResponseType(typeof(List<ProductsByQtyResponse>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [Route("GetProductsByQty")]
        public IActionResult GetProductsByQty([FromBody] ProductsByQtyRequest input)
        {
            var request = new ProductByQtyRequest(input.Quantity);
            useCase.Execute(request);

            return presenter.ViewModel;
        }
    }
}
