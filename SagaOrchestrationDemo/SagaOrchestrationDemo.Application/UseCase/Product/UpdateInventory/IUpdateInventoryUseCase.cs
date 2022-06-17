namespace SagaOrchestrationDemo.Application.UseCase.Product.UpdateInventory
{
    public interface IUpdateInventoryUseCase
    {
        void Execute(UpdateInventoryRequest request);
    }
}
