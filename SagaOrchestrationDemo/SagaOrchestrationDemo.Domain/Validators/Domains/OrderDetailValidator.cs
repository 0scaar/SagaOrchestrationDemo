using FluentValidation;
using SagaOrchestrationDemo.Domain.Domains;

namespace SagaOrchestrationDemo.Domain.Validators.Domains
{
    public class OrderDetailValidator : AbstractValidator<OrderDetail>
    {
        public OrderDetailValidator()
        {
            RuleFor(r => r.OrderId).NotNull().NotEmpty();
            RuleFor(r => r.ProductId).NotNull().NotEmpty();
        }
    }
}
