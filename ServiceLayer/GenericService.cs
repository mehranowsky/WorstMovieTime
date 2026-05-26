using Microsoft.EntityFrameworkCore;
using ModelLayer;
using ModelLayer.Context;

namespace ServiceLayer
{
    public class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly WorstMoviesDbContext db;
        private readonly DbSet<T> dbSet;
        public GenericService(WorstMoviesDbContext context)
        {
            db = context;
            dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }
        public T? GetEntity(int id)
        {
            return dbSet.Find(id);
        }
        public bool Add(T entity)
        {
            try
            {
                dbSet.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                dbSet.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception) { 
                return false;
            }
        }

        public bool Update(int id)
        {
            try
            {
                var entity = GetEntity(id);
                dbSet.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false ;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                dbSet.Entry(entity).State = EntityState.Deleted;
                return true;
            }
            catch (Exception) { 
                return false;
            }
        }        
                
        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
