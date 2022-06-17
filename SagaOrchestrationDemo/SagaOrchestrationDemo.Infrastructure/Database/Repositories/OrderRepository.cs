using AutoMapper;
using SagaOrchestrationDemo.Application.Interfaces;
using SagaOrchestrationDemo.Domain.Domains;
using System;
using System.Linq;

namespace SagaOrchestrationDemo.Infrastructure.Database.Repositories
{
    public class OrderRepository : IOrder
    {
        private readonly IMapper mapper;

        public OrderRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Create(Order order)
        {
            using (var context = new Context())
            {
                var model = mapper.Map<Entities.Order>(order);
                context.Orders.Add(model);
                return context.SaveChanges();
            }
        }

        public int DeleteOrder(Guid id)
        {
            using (var context = new Context())
            {
                var order = context.Orders.Where(f => f.Id == id).First();
                context.Orders.Remove(order);

                return context.SaveChanges();
            }
        }
    }
}
