using System;

namespace SagaOrchestrationDemo.WebApi.UseCases.Order.Delete
{
    public class DeleteOrderResponse
    {
        public Guid IdOrder { get; private set; }

        public DeleteOrderResponse(Guid idOrder)
        {
            IdOrder = idOrder;
        }
    }
}
