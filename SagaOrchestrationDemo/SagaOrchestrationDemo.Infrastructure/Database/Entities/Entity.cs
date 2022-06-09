using System;

namespace SagaOrchestrationDemo.Infrastructure.Database.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
    }
}
