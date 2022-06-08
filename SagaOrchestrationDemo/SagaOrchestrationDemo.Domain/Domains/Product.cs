using System;
using System.Collections.Generic;

namespace SagaOrchestrationDemo.Domain.Domains
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public short Quantity { get; private set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public Product(Guid id, string name, short quantity)
            : base(id)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
