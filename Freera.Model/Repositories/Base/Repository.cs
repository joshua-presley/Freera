using Freera.Exceptions;
using Freera.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Freera.Model
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        internal FreeraContext context;
        internal DbSet<T> dbSet;

        public Repository()
        {
        }

        internal void SetContext(FreeraContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }


        public void Add(T item)
        {
            dbSet.Add(item);
        }

        public void Delete(T item)
        {
            if (context.Entry(item).State == EntityState.Detached)
            {
                dbSet.Attach(item);
            }
            dbSet.Remove(item);
        }

        public virtual void Delete(Guid id)
        {
            var item = dbSet.Find(id);
            if(item != null)
            {
                dbSet.Remove(item);
            }
        }

        public virtual IQueryable<T> QueryAll()
        {
            return dbSet;
        }

        public virtual T QueryById(Guid id)
        {
            var item = dbSet.Find(id);
            if(item == null)
            {
                throw new ModelNotFoundException(id, typeof(T));
            }
            return item;
        }

        public virtual void Update(T item)
        {
            dbSet.Attach(item);
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
