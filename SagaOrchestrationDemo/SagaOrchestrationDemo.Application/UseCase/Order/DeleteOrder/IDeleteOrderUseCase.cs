namespace SagaOrchestrationDemo.Application.UseCase.Order.DeleteOrder
{
    public interface IDeleteOrderUseCase
    {
        void Execute(DeleteOrderRequest request);
    }
}
