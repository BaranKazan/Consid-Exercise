namespace Library.Service
{

    /*
     * This class serves to run services that has been implemented by Runnable interface.
     * It will execute code that follow Command design pattern. 
     */
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
