using Domain = SagaOrchestrationDemo.Domain.Domains;
using System.Collections.Generic;

namespace SagaOrchestrationDemo.Application.UseCase.Product.ProductByQty
{
    public class ProductByQtyRequest 
    {
        public int Qty { get; private set; }
        public List<Domain::Product> Products { get; set; }

        public ProductByQtyRequest(int qty)
        {
            Qty = qty;
        }
    }
}
