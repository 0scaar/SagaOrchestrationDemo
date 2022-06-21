using System;

namespace SagaOrchestrationDemo.WebApi.UseCases.Order.Delete
{
    public class DeleteOrderRequest
    {
        public Guid IdOrder { get; set; }
    }
}
