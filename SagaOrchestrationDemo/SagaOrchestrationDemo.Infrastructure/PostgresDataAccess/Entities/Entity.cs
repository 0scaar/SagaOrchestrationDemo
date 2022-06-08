using System;

namespace SagaOrchestrationDemo.Infrastructure.PostgresDataAccess.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
    }
}
