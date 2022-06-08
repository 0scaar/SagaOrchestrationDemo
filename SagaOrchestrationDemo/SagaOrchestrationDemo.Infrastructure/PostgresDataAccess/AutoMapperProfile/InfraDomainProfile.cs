using AutoMapper;
using Entity = SagaOrchestrationDemo.Infrastructure.PostgresDataAccess.Entities;
using Domains = SagaOrchestrationDemo.Domain.Domains;

namespace SagaOrchestrationDemo.Infrastructure.PostgresDataAccess.AutoMapperProfile
{
    public class InfraDomainProfile : Profile
    {
        public InfraDomainProfile()
        {
            CreateMap<Entity.Customer, Domains.Customer>().ReverseMap();
            CreateMap<Entity.Product, Domains.Product>().ReverseMap();
            CreateMap<Entity.Order, Domains.Order>().ReverseMap();
            CreateMap<Entity.OrderDetail, Domains.OrderDetail>().ReverseMap();
        }
    }
}
