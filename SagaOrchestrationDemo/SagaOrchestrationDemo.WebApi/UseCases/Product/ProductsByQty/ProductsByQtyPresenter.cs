using Microsoft.AspNetCore.Mvc;
using SagaOrchestrationDemo.Application.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace SagaOrchestrationDemo.WebApi.UseCases.Product.ProductsByQty
{
    public class ProductsByQtyPresenter : IOutputPort<List<Domain.Domains.Product>>
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            var problemDetails = new ProblemDetails()
            {
                Title = "Error",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetails);
        }

        public void NotFound(string message)
            => ViewModel = new NotFoundObjectResult(message);

        public void Standard(List<Domain.Domains.Product> output)
        {
            var response = output
                .Select(s => new ProductsByQtyResponse(s.Name, s.Quantity))
                .ToList();

            ViewModel = new OkObjectResult(response);
        }
    }
}
