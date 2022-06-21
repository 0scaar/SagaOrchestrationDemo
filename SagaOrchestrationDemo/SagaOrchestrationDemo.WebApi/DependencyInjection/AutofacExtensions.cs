using Autofac;
using SagaOrchestrationDemo.Application.Boundaries.Order;
using SagaOrchestrationDemo.Application.Boundaries.Product;
using SagaOrchestrationDemo.Application.Helpers;
using SagaOrchestrationDemo.Domain.Domains;
using SagaOrchestrationDemo.Infrastructure.Modules;
using SagaOrchestrationDemo.WebApi.UseCases.Order.Create;
using SagaOrchestrationDemo.WebApi.UseCases.Order.Delete;
using SagaOrchestrationDemo.WebApi.UseCases.Product.Inventory;
using SagaOrchestrationDemo.WebApi.UseCases.Product.ProductsByQty;
using System.Collections.Generic;

namespace SagaOrchestrationDemo.WebApi.DependencyInjection
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder AddAutofacRegistration(this ContainerBuilder builder)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureModule>();

            builder.RegisterType<ProductsByQtyPresenter>().As<IOutputPort<List<Product>>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ProductInventoryPresenter>().As<IOutputPort<InventoryBoundary>>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<CreateOrderPresenter>().As<IOutputPort<CreateBoundary>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<DeleteOrderPresenter>().As<IOutputPort<DeleteBoundary>>().AsSelf().InstancePerLifetimeScope();

            return builder;
        }
    }
}
