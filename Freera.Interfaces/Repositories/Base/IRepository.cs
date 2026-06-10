using System;
using System.Collections.Generic;
using System.Text;

namespace Freera.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> QueryAll();
        T QueryById(Guid id);
        void Add(T item);
        void Update(T item);
        void Delete(Guid id);
        void Delete(T item);
    }
}
