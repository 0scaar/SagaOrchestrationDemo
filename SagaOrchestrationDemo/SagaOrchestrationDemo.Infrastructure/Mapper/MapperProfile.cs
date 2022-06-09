using AutoMapper;
using Entity = SagaOrchestrationDemo.Infrastructure.Database.Entities;
using Domains = SagaOrchestrationDemo.Domain.Domains;

namespace SagaOrchestrationDemo.Infrastructure.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Entity.Customer, Domains.Customer>().ReverseMap();
            CreateMap<Entity.Product, Domains.Product>().ReverseMap();
            CreateMap<Entity.Order, Domains.Order>().ReverseMap();
            CreateMap<Entity.OrderDetail, Domains.OrderDetail>().ReverseMap();
        }
    }
}
