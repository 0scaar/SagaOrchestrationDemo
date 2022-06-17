using SagaOrchestrationDemo.Application.Interfaces;
using System.Linq;

namespace SagaOrchestrationDemo.Application.UseCase.Product.UpdateInventory.RequestHandlers
{
    public class GetInventoryProductHandler : Handler<UpdateInventoryRequest>
    {
        private readonly IProduct product;

        public GetInventoryProductHandler(IProduct product)
        {
            this.product = product;
        }

        public override void ProcessRequest(UpdateInventoryRequest request)
        {
            var productIds = request.ProductInventories.Select(s => s.ProductId).ToList();

            request.ProductsOutput = product.GetProducts(productIds);

            Sucessor?.ProcessRequest(request);
        }
    }
}
