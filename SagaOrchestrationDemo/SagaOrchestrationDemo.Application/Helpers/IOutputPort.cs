namespace SagaOrchestrationDemo.Application.Helpers
{
    public interface IOutputPort<T>
    {
        void Standard(T output);
        void NotFound(string message);
        void Error(string message);
    }
}
