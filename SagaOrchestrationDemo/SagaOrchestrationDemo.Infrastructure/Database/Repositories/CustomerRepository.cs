using AutoMapper;
using SagaOrchestrationDemo.Application.Interfaces;
using SagaOrchestrationDemo.Domain.Domains;
using System.Linq;

namespace SagaOrchestrationDemo.Infrastructure.Database.Repositories
{
    public class CustomerRepository : ICustomer
    {
        private readonly IMapper mapper;

        public CustomerRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Customer GetCustomer(string code)
        {
            using (var context = new Context())
            {
                return mapper.Map<Customer>(context.Customers.Where(f => f.Code == code).First());
            }
        }
    }
}
