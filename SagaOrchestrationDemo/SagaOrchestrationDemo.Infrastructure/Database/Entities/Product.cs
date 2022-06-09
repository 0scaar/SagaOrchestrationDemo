using System.Collections.Generic;

namespace SagaOrchestrationDemo.Infrastructure.Database.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public short Quantity { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
