using Microsoft.AspNetCore.Mvc;
using SagaOrchestrationDemo.Application.Boundaries.Order;
using SagaOrchestrationDemo.Application.Helpers;
using SagaOrchestrationDemo.WebApi.Helpers;

namespace SagaOrchestrationDemo.WebApi.UseCases.Order.Delete
{
    public class DeleteOrderPresenter : Presenter, IOutputPort<DeleteBoundary>
    {
        public void Standard(DeleteBoundary output)
        {
            var response = new DeleteOrderResponse(output.OrderId);

            ViewModel = new OkObjectResult(response);
        }
    }
}
