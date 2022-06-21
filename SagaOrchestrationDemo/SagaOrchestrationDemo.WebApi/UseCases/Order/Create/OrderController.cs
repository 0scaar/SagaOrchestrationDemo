using Microsoft.AspNetCore.Mvc;
using SagaOrchestrationDemo.Application.UseCase.Order.CreateOrder;
using App = SagaOrchestrationDemo.Application.UseCase.Order.CreateOrder;
using System.Linq;

namespace SagaOrchestrationDemo.WebApi.UseCases.Order.Create
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICreateOrderUseCase useCase;
        private readonly CreateOrderPresenter presenter;

        public OrderController(ICreateOrderUseCase useCase, CreateOrderPresenter presenter)
        {
            this.useCase = useCase;
            this.presenter = presenter;
        }

        [HttpPost()]
        [ProducesResponseType(typeof(CreateOrderResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [Route("CreateOrder")]
        public IActionResult CreateOrder([FromBody] CreateOrderRequest input)
        {
            var detail = input.OrderDetails
                .Select(s => new App::CreateOrderDetailRequest(s.ProductId, s.UnitPrice, s.Quantity))
                .ToList();

            var request = new App::CreateOrderRequest(
                input.CustomerCode,
                input.ShipAddress,
                input.ShipCity,
                input.ShipCountry,
                input.ShipPostalCode,
                detail);

            useCase.Execute(request);

            return presenter.ViewModel;
        }
    }
}
