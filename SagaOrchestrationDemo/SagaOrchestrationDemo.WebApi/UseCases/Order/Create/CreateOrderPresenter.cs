using Microsoft.AspNetCore.Mvc;
using SagaOrchestrationDemo.Application.Boundaries.Order;
using SagaOrchestrationDemo.Application.Helpers;
using SagaOrchestrationDemo.WebApi.Helpers;
using System;

namespace SagaOrchestrationDemo.WebApi.UseCases.Order.Create
{
    public class CreateOrderPresenter : Presenter, IOutputPort<CreateBoundary>
    {
        public void Standard(CreateBoundary output)
        {
            var response = new CreateOrderResponse(output.OrderId);

            ViewModel = new OkObjectResult(response);
        }
    }
}
