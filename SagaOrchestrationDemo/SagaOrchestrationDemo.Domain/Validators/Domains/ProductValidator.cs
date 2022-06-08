using FluentValidation;
using SagaOrchestrationDemo.Domain.Domains;

namespace SagaOrchestrationDemo.Domain.Validators.Domains
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(r => r.Id).NotNull().NotEmpty();
        }
    }
}
