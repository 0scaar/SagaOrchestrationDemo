using SagaOrchestrationDemo.Application.Helpers;
using SagaOrchestrationDemo.Application.Interfaces;
using System;

namespace SagaOrchestrationDemo.Application.UseCase.Order.DeleteOrder
{
    public class DeleteOrderUseCase : IDeleteOrderUseCase
    {
        private readonly IOrder order;
        private readonly IOutputPort<Guid> outputPort;

        public DeleteOrderUseCase(IOrder order, IOutputPort<Guid> outputPort)
        {
            this.order = order;
            this.outputPort = outputPort;
        }

        public void Execute(DeleteOrderRequest request)
        {
            try
            {
                var orderDeleted = order.DeleteOrder(request.IdOrder);

                if (orderDeleted == 0)
                    outputPort.NotFound("Order not found");
                else
                    outputPort.Standard(request.IdOrder);
            }
            catch (Exception ex)
            {
                outputPort.Error($"Error on DeleteOrderUseCase: {ex.Message}");
            }
        }
    }
}
