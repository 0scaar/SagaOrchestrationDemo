using System;

namespace SagaOrchestrationDemo.Application.Boundaries.Order
{
    public class DeleteBoundary
    {
        public Guid OrderId { get; private set; }

        public DeleteBoundary(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
