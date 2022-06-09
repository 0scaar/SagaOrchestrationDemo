using System.Collections.Generic;

namespace SagaOrchestrationDemo.Infrastructure.Database.Entities
{
    public class Customer : Entity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
