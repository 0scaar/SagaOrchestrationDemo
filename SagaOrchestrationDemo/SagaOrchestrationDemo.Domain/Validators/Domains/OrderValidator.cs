using FluentValidation;
using SagaOrchestrationDemo.Domain.Domains;

namespace SagaOrchestrationDemo.Domain.Validators.Domains
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(r => r.Id).NotNull().NotEmpty();
        }
    }
}
