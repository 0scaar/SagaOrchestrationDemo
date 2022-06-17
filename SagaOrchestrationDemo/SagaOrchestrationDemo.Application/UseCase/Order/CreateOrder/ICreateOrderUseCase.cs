namespace SagaOrchestrationDemo.Application.UseCase.Order.CreateOrder
{
    public interface ICreateOrderUseCase
    {
        void Execute(CreateOrderRequest request);
    }
}
