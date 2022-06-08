using FluentValidation;
using SagaOrchestrationDemo.Domain.Domains;

namespace SagaOrchestrationDemo.Domain.Validators.Domains
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(r => r.Id).NotNull().NotEmpty();
            RuleFor(r => r.Code).NotNull().NotEmpty().Length(5,5);
            RuleFor(r => r.Name).NotNull().NotEmpty().MaximumLength(40);
        }
    }
}
