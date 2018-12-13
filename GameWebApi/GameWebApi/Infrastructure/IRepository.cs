using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebApi.Infrastructure.Repositories
{
    public interface IRepository<T> where T:class
    {    
        IEnumerable<T> getAll();
        T getById(int id);
        int Insert(T entity);
        bool Remove(int id);
        bool Update(T entity);
    }
}
