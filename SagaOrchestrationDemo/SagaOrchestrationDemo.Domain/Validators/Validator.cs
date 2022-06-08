using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SagaOrchestrationDemo.Domain.Validators
{
    public static class Validator<Model>
    {
        public static Task<List<ValidationFailure>> Validate(Model model, IEnumerable<IValidator<Model>> validators)
        {
            var failures = validators
                .Select(v => v.Validate(model))
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Any())
                throw new ValidationException(failures);

            return Task.FromResult(failures);
        }
    }
}
