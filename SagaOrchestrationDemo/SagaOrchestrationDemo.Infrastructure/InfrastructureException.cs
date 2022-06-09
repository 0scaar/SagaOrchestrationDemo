using System;

namespace SagaOrchestrationDemo.Infrastructure
{
    public class InfrastructureException : Exception
    {
        public InfrastructureException(string businessMessage)
               : base(businessMessage)
        {
        }
    }
}
