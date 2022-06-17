using SagaOrchestrationDemo.Application.Interfaces;
using System.Linq;

namespace SagaOrchestrationDemo.Application.UseCase.Product.UpdateInventory.RequestHandlers
{
    public class GetProductsHandler : Handler<UpdateInventoryRequest>
    {
        private readonly IProduct product;

        public GetProductsHandler(IProduct product)
        {
            this.product = product;
        }

        public override void ProcessRequest(UpdateInventoryRequest request)
        {
            var productIds = request.ProductInventories.Select(s => s.ProductId).ToList();

            request.Products = product.GetProducts(productIds);
            var allProductIds = request.Products.Select(p => p.Id).ToList();

            if (!productIds.Any(id => allProductIds.Contains(id)))
            {
                request.ExistAllProduct = false;
                return;
            }
                
            Sucessor?.ProcessRequest(request);
        }
    }
}
