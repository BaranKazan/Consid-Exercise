using System;
using System.Collections.Generic;

namespace Libary.DAO
{
    public interface DaoInterface<T>
    {
        public T Get(int id);
        public List<T> GetAll();
        public bool Save(T t);
        public bool Update(T t);
        public bool Delete(int id);
    }
}
