
namespace Freera.Interfaces
{
    public interface IRepository
    {
        IQueryable<T> QueryAll<T>();
        T QueryById<T>(Guid id);
        void Add<T>(T item);
        void Update<T>(T item);
        void Delete(Guid id);
        void Delete<T>(T item);
    }
}
