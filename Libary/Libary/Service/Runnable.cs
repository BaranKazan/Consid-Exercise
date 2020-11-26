namespace Library.Service
{

    /*
     * Runnable interface with the single method. 
     * This interface is used to apply Command design pattern.
     */
    public interface Runnable<T>
    {
        public T Run();
    }
}
