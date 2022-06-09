using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using System;
using System.Linq;

namespace SagaOrchestrationDemo.WebApi.DependencyInjection
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection Swagger(this IServiceCollection services)
        {
            services.AddSwaggerDocument(document =>
            {
                document.Title = "SagaOrchestrationDemo.WebApi";
                document.Version = "v1";
                //document.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT Token"));

                //document.DocumentProcessors.Add(new SecurityDefinitionAppender("JWT Token", new List<string>(),
                //    new OpenApiSecurityScheme
                //    {
                //        Type = OpenApiSecuritySchemeType.ApiKey,
                //        Name = "Authorization",
                //        Description = "Copy 'Bearer ' + valid JWT token into field",
                //        In = OpenApiSecurityApiKeyLocation.Header
                //    }));
                document.PostProcess = s =>
                {
                    s.Paths.ToList().ForEach(p =>
                    {
                        p.Value.Parameters.Add(
                        new OpenApiParameter()
                        {
                            Kind = OpenApiParameterKind.Header,
                            Type = NJsonSchema.JsonObjectType.String,
                            IsRequired = false,
                            Name = "Accept-Language",
                            Description = "pt-BR or en-US",
                            Default = "pt-BR"
                        });
                    });
                };
            });

            return services;
        }

        public static IApplicationBuilder Swagger(this IApplicationBuilder app)
        {
            app.UseOpenApi(config =>
            {
                config.PostProcess = (document, request) =>
                {
                    document.Host = ExtractHost(request);
                    document.BasePath = ExtractPath(request);
                    document.Schemes.Clear();
                };
            });

            app.UseSwaggerUi3(config =>
            {
                config.TransformToExternalPath = (route, request) => ExtractPath(request) + route;
            });

            return app;
        }

        private static string ExtractHost(HttpRequest request) =>
            request.Headers.ContainsKey("X-Forwarded-Host") ?
                new Uri($"{ExtractProto(request)}://{request.Headers["X-Forwarded-Host"].First()}").Host :
                    request.Host.Value;

        private static string ExtractProto(HttpRequest request) =>
            request.Headers["X-Forwarded-Proto"].FirstOrDefault() ?? request.Protocol;

        private static string ExtractPath(HttpRequest request) =>
            request.Headers.ContainsKey("X-Forwarded-Prefix") ?
                request.Headers["X-Forwarded-Prefix"].FirstOrDefault() :
                string.Empty;
    }
}
