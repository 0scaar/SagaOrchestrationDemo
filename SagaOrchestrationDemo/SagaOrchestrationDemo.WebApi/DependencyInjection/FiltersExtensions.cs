using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SagaOrchestrationDemo.WebApi.DependencyInjection
{
    public static class FiltersExtensions
    {
        public static IServiceCollection AddCustomFilters(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                //options.Filters.Add(typeof(DomainExceptionFilter));
                //options.Filters.Add(typeof(ValidateModelAttribute));
                //options.Filters.Add(typeof(NotificationFilter));
                //options.Conventions.Add(new NotFoundResultApiConvention());
                //options.Conventions.Add(new ProblemDetailsResultApiConvention());
            });

            return services;
        }
    }
}
