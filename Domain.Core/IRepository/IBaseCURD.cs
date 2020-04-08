using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.IRepository
{
    public interface IBaseCRUD<T>
    {
        IEnumerable<T> Get();
        T GetBy(int ID, string name = null);
        int Add(T item);
        bool DeleteByID(int ID);
        bool Update(T item);
        bool Save();
    }
}
