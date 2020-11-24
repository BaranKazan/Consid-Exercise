using System;
namespace Libary.Service
{
    public interface Runnable<T>
    {
        public T Run();
    }
}
