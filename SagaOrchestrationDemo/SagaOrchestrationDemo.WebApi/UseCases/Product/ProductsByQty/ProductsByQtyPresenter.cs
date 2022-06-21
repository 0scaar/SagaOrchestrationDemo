using Microsoft.AspNetCore.Mvc;
using SagaOrchestrationDemo.Application.Helpers;
using SagaOrchestrationDemo.WebApi.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace SagaOrchestrationDemo.WebApi.UseCases.Product.ProductsByQty
{
    public class ProductsByQtyPresenter : Presenter, IOutputPort<List<Domain.Domains.Product>>
    {
        public void Standard(List<Domain.Domains.Product> output)
        {
            var response = output
                .Select(s => new ProductsByQtyResponse(s.Name, s.Quantity))
                .ToList();

            ViewModel = new OkObjectResult(response);
        }
    }
}
