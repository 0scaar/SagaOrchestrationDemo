using SagaOrchestrationDemo.Domain.Domains;
using System;

namespace SagaOrchestrationDemo.Application.Interfaces
{
    public interface IOrder
    {
        int Create(Order order);
        int DeleteOrder(Guid id);
    }
}
