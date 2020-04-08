using System.Collections.Generic;

namespace Product.Microservice.Respository
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> Get();
        T GetBy(int ID,string name = null);
        bool Add(T item);
        bool DeleteByID(int ID);
        bool Update(T item);
        bool Save();
    }
}
