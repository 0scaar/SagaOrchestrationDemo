using SagaOrchestrationDemo.Application.Helpers;
using SagaOrchestrationDemo.Application.UseCase.Order.CreateOrder.RequestHandlers;
using System;

namespace SagaOrchestrationDemo.Application.UseCase.Order.CreateOrder
{
    public class CreateOrderUseCase : ICreateOrderUseCase
    {
        private readonly GetCustomerHandler getCustomerHandler;
        private readonly IOutputPort<Guid> outputPort;

        public CreateOrderUseCase(GetCustomerHandler getCustomerHandler, 
            SaveOrderHandler saveOrderHandler,
            IOutputPort<Guid> outputPort)
        {
            getCustomerHandler.SetSucessor(saveOrderHandler);

            this.getCustomerHandler = getCustomerHandler;
            this.outputPort = outputPort;
        }

        public void Execute(CreateOrderRequest request)
        {
            try
            {
                getCustomerHandler.ProcessRequest(request);

                if (!request.ExistCustomer)
                    outputPort.NotFound("Customer not found");
                else
                    outputPort.Standard(request.OrderId);
            }
            catch (Exception ex)
            {
                outputPort.Error($"Error on CreateOrderUseCase: {ex.Message}");
            }
        }
    }
}
