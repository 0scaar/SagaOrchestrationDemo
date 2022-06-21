using Microsoft.AspNetCore.Mvc;
using SagaOrchestrationDemo.Application.UseCase.Order.DeleteOrder;
using App = SagaOrchestrationDemo.Application.UseCase.Order.DeleteOrder;

namespace SagaOrchestrationDemo.WebApi.UseCases.Order.Delete
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IDeleteOrderUseCase useCase;
        private readonly DeleteOrderPresenter presenter;

        public OrderController(IDeleteOrderUseCase useCase, DeleteOrderPresenter presenter)
        {
            this.useCase = useCase;
            this.presenter = presenter;
        }

        [HttpPost()]
        [ProducesResponseType(typeof(DeleteOrderResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [Route("DeleteOrder")]
        public IActionResult DeleteOrder([FromBody] DeleteOrderRequest input)
        {
            var request = new App::DeleteOrderRequest(input.IdOrder);

            useCase.Execute(request);

            return presenter.ViewModel;
        }
    }
}
