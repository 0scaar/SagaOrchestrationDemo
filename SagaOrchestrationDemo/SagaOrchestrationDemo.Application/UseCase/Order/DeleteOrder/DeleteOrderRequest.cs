using System;

namespace SagaOrchestrationDemo.Application.UseCase.Order.DeleteOrder
{
    public class DeleteOrderRequest
    {
        public Guid IdOrder { get; private set; }

        public DeleteOrderRequest(Guid idOrder)
        {
            IdOrder = idOrder;
        }
    }
}
