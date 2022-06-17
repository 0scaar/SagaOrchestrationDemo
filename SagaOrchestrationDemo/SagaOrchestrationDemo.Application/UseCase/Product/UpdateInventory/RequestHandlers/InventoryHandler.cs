using SagaOrchestrationDemo.Application.Interfaces;
using System.Linq;

namespace SagaOrchestrationDemo.Application.UseCase.Product.UpdateInventory.RequestHandlers
{
    public class InventoryHandler : Handler<UpdateInventoryRequest>
    {
        private readonly IProduct product;

        public InventoryHandler(IProduct product)
        {
            this.product = product;
        }

        public override void ProcessRequest(UpdateInventoryRequest request)
        {
            request.ValidateUpdate = request.ProductInventories
                .Join(request.Products, i => i.ProductId, p => p.Id, (i, p) => new { i, p })
                .Any(a => a.p.Quantity < a.i.Quantity);

            if (!request.ValidateUpdate)
                return;

            request.ProductInventories.ForEach(p =>
            {
                var filteredProduct = request.Products.Where(f => f.Id == p.ProductId).FirstOrDefault();
                product.UpdateInventory(p.ProductId, (short)(filteredProduct.Quantity - p.Quantity));
            });

            Sucessor?.ProcessRequest(request);
        }
    }
}
