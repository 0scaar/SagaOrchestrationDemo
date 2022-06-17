using AutoMapper;
using SagaOrchestrationDemo.Application.Interfaces;
using SagaOrchestrationDemo.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SagaOrchestrationDemo.Infrastructure.Database.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly IMapper mapper;

        public ProductRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public List<Product> GetProducts(int qty)
        {
            using (var context = new Context())
            {
                var products = context.Products.Where(f => f.Quantity <= qty).ToList();
                return mapper.Map<List<Product>>(products);
            }
        }

        public List<Product> GetProducts(List<Guid> Ids)
        {
            using (var context = new Context())
            {
                var products = context.Products.Where(f => Ids.Contains(f.Id)).ToList();
                return mapper.Map<List<Product>>(products);
            }
        }

        public void UpdateInventory(Guid id, short qty)
        {
            using (var context = new Context())
            {
                context.Products
                    .Where(s => s.Id == id && s.Quantity <= qty)
                    .FirstOrDefault().Quantity = qty;

                context.SaveChanges();
            }
        }
    }
}
