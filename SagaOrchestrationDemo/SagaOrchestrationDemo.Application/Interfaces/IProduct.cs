using SagaOrchestrationDemo.Domain.Domains;
using System;
using System.Collections.Generic;

namespace SagaOrchestrationDemo.Application.Interfaces
{
    public interface IProduct
    {
        List<Product> GetProducts(List<Guid> Ids);
        List<Product> GetProducts(int qty);
        void UpdateInventory(Guid id, short qty);
    }
}
