using Microsoft.EntityFrameworkCore.Diagnostics;
using ModelLayer;

namespace ServiceLayer
{
    public interface IGenericService<T> : IDisposable
    {
        IEnumerable<T> GetAll();
        T? GetEntity(int id);        
        bool Add(T entity);
        bool Update(T entity);
        bool Update(int id);
        bool Delete(T entity);
        void Save();
    }
}
