using SagaOrchestrationDemo.Application.Interfaces;
using SagaOrchestrationDemo.Domain.Enums;
using System;
using System.Linq;
using Domain = SagaOrchestrationDemo.Domain.Domains;

namespace SagaOrchestrationDemo.Application.UseCase.Order.CreateOrder.RequestHandlers
{
    public class SaveOrderHandler : Handler<CreateOrderRequest>
    {
        private readonly IOrder orderRepository;

        public SaveOrderHandler(IOrder orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public override void ProcessRequest(CreateOrderRequest request)
        {
            var order = new Domain::Order(
                Guid.NewGuid(),
                request.CustomerId,
                DateTime.Now,
                request.ShipAddress,
                request.ShipCity,
                request.ShipCountry,
                request.ShipPostalCode,
                DiscountType.Percentage,
                10,
                ShippingType.Road
            );

            var orderDetail = request.OrderDetails
                .Select(s => new Domain::OrderDetail(order.Id, s.ProductId, s.UnitPrice, s.Quantity))
                .ToList();

            order.OrderDetails = orderDetail;

            orderRepository.Create(order);

            request.OrderId = order.Id;

            Sucessor?.ProcessRequest(request);
        }
    }
}
