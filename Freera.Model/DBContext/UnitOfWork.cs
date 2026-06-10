namespace Freera.Model
{
    public class UnitOfWork : IDisposable
    {
        /// <summary>
        /// Get a repository by type.
        /// </summary>
        /// <typeparam name="TRepository">Type of the repository object.</typeparam>
        /// <typeparam name="TModel">Type of the model object.</typeparam>
        /// <returns>Instantiated repository with correct context.</returns>
        public TRepository GetRepository<TRepository, TModel>() 
            where TRepository : Repository<TModel>
            where TModel : class
        {
            TRepository repo = Activator.CreateInstance<TRepository>();
            repo.SetContext(context);
            return repo;
        }

        public void Save()
        {
            context.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private FreeraContext context = new FreeraContext();
        private bool disposed = false;
    }
}
