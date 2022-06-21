using System;

namespace SagaOrchestrationDemo.WebApi.UseCases.Order.Create
{
    public class CreateOrderResponse
    {
        public Guid OrderId { get; private set; }

        public CreateOrderResponse(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
