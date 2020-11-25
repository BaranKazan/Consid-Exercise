namespace Library.Service
{
    public class ServiceRunner<T>
    {
        private Runnable<T> service;

        public ServiceRunner(Runnable<T> service)
        {
            this.service = service;
        }

        public T Run()
        {
            T serviceResult = this.service.Run();
            return serviceResult;
        }
    }
}
