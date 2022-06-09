using Autofac;
using SagaOrchestrationDemo.Infrastructure.Modules;

namespace SagaOrchestrationDemo.WebApi.DependencyInjection
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder AddAutofacRegistration(this ContainerBuilder builder)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureModule>();
            //builder.RegisterModule<WebapiModule>();

            return builder;
        }
    }
}
