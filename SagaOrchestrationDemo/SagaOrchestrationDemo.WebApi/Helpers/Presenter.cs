using Microsoft.AspNetCore.Mvc;

namespace SagaOrchestrationDemo.WebApi.Helpers
{
    public abstract class Presenter
    {
        public IActionResult ViewModel { get; protected set; }

        public void Error(string message)
        {
            var problemDetails = new ProblemDetails()
            {
                Title = "Error",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetails);
        }

        public virtual void Conflict(string message)
        {
            var problemDetails = new ProblemDetails()
            {
                Title = "An conflict occurred",
                Detail = message
            };

            ViewModel = new ConflictObjectResult(problemDetails);
        }

        public void NotFound(string message)
            => ViewModel = new NotFoundObjectResult(message);
    }
}
