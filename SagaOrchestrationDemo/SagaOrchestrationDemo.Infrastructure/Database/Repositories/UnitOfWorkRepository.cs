using SagaOrchestrationDemo.Application.Interfaces;

namespace SagaOrchestrationDemo.Infrastructure.Database.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        public int SaveChanges()
        {
            using (var context = new Context())
            {
                return context.SaveChanges();
            }   
        }
    }
}
