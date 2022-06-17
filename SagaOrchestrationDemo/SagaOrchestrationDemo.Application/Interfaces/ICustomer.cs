using SagaOrchestrationDemo.Domain.Domains;

namespace SagaOrchestrationDemo.Application.Interfaces
{
    public interface ICustomer
    {
        Customer GetCustomer(string code);
    }
}
