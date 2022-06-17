namespace SagaOrchestrationDemo.Application.Interfaces
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}
