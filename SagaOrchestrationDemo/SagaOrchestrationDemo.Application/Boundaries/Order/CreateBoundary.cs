using System;

namespace SagaOrchestrationDemo.Application.Boundaries.Order
{
    public class CreateBoundary
    {
        public Guid OrderId { get; private set; }

        public CreateBoundary(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
