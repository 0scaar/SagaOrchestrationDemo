using SagaOrchestrationDemo.Application.Helpers;
using Domain = SagaOrchestrationDemo.Domain.Domains;
using System;
using System.Collections.Generic;
using SagaOrchestrationDemo.Application.UseCase.Product.UpdateInventory.RequestHandlers;
using SagaOrchestrationDemo.Application.Boundaries.Product;

namespace SagaOrchestrationDemo.Application.UseCase.Product.UpdateInventory
{
    public class UpdateInventoryUseCase : IUpdateInventoryUseCase
    {
        private readonly GetProductsHandler getProductsHandler;
        private readonly IOutputPort<InventoryBoundary> outputPort;

        public UpdateInventoryUseCase(IOutputPort<InventoryBoundary> outputPort, 
            GetProductsHandler getProductsHandler,
            InventoryHandler inventoryHandler,
            GetInventoryProductHandler getInventoryProductHandler)
        {
            getProductsHandler
                .SetSucessor(inventoryHandler)
                .SetSucessor(getInventoryProductHandler);

            this.outputPort = outputPort;
            this.getProductsHandler = getProductsHandler;
        }

        public void Execute(UpdateInventoryRequest request)
        {
            try
            {
                getProductsHandler.ProcessRequest(request);

                if (!request.ExistAllProduct)
                    outputPort.NotFound("Not all products were found");
                else if (!request.ValidateUpdate)
                    outputPort.Error("Error updating product stock");
                else
                    outputPort.Standard(new InventoryBoundary(request.ProductsOutput));
            }
            catch (Exception ex)
            {
                outputPort.Error($"Error on UpdateInventoryUseCase: {ex.Message}");
            }
        }
    }
}
