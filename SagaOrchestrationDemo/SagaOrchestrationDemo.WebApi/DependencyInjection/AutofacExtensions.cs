using Autofac;
using SagaOrchestrationDemo.Application.Helpers;
using SagaOrchestrationDemo.Domain.Domains;
using SagaOrchestrationDemo.Infrastructure.Modules;
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

            return builder;
        }
    }
}
