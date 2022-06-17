using SagaOrchestrationDemo.Application.Interfaces;

namespace SagaOrchestrationDemo.Application.UseCase.Order.CreateOrder.RequestHandlers
{
    public class GetCustomerHandler : Handler<CreateOrderRequest>
    {
        private readonly ICustomer customer;

        public GetCustomerHandler(ICustomer customer)
        {
            this.customer = customer;
        }

        public override void ProcessRequest(CreateOrderRequest request)
        {
            var customerInfo = customer.GetCustomer(request.CustomerCode);

            if (customerInfo == null)
            {
                request.ExistCustomer = false;
                return;
            }

            request.CustomerId = customerInfo.Id;

            Sucessor?.ProcessRequest(request);
        }
    }
}
