using SagaOrchestrationDemo.Application.Interfaces;
using System.Linq;

namespace SagaOrchestrationDemo.Application.UseCase.Product.UpdateInventory.RequestHandlers
{
    public class InventoryHandler : Handler<UpdateInventoryRequest>
    {
        private readonly IProduct product;
        private readonly IUnitOfWork unitOfWork;

        public InventoryHandler(IProduct product, IUnitOfWork unitOfWork)
        {
            this.product = product;
            this.unitOfWork = unitOfWork;
        }

        public override void ProcessRequest(UpdateInventoryRequest request)
        {
            request.ValidateUpdate = true;

            request.ProductInventories.ForEach(p =>
            {
                var filteredProduct = request.Products.Where(f => f.Id == p.ProductId).FirstOrDefault();

                if (filteredProduct.Quantity >= p.Quantity)
                    product.UpdateInventory(p.ProductId, (short)(filteredProduct.Quantity - p.Quantity));
                else
                    request.ValidateUpdate = false;
            });

            if (request.ValidateUpdate)
                unitOfWork.SaveChanges();

            Sucessor?.ProcessRequest(request);
        }
    }
}
