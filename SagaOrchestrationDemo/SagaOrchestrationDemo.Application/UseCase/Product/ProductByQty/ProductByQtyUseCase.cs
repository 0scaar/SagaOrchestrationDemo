using SagaOrchestrationDemo.Application.Helpers;
using SagaOrchestrationDemo.Application.Interfaces;
using Domain = SagaOrchestrationDemo.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SagaOrchestrationDemo.Application.UseCase.Product.ProductByQty
{
    public class ProductByQtyUseCase : IProductByQtyUseCase
    {
        private readonly IProduct product;
        private readonly IOutputPort<List<Domain::Product>> outputPort;

        public ProductByQtyUseCase(IProduct product, IOutputPort<List<Domain::Product>> outputPort)
        {
            this.product = product;
            this.outputPort = outputPort;
        }

        public void Execute(ProductByQtyRequest request)
        {
            try
            {
                var products = product.GetProducts(request.Qty);

                if (!products.Any())
                    outputPort.NotFound($"Products not found");
                else
                    outputPort.Standard(products);
            }
            catch (Exception ex)
            {
                outputPort.Error($"Error on ProductByQtyUseCase: {ex.Message}");
            }
        }
    }
}
