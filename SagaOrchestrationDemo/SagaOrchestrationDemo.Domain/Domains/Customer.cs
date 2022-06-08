using System;
using System.Collections.Generic;

namespace SagaOrchestrationDemo.Domain.Domains
{
    public class Customer : Entity
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public List<Order> Orders { get; set; }

        public Customer(Guid id, string code, string name) 
            : base(id)
        {
            Code = code;
            Name = name;
        }
    }
}
