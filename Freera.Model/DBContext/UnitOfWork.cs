using Freera.Interfaces;
using Freera.Interfaces.Repositories;
using Freera.Exceptions;

namespace Freera.Model
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        /// <summary>
        /// Constructor for Unit Of Work.
        /// </summary>
        /// <remarks>
        /// If new repositories are added, they MUST be added here as well.
        /// </remarks>
        public UnitOfWork(IWorkItemRepository workItemRepository, IWorkItemStateRepository workItemStateRepository)
        {
            this.repositories.Add(workItemRepository);
            this.repositories.Add(workItemStateRepository);
        }

        /// <summary>
        /// Get a repository by type.
        /// </summary>
        /// <typeparam name="TRepository">Type of the repository object.</typeparam>
        /// <typeparam name="TModel">Type of the model object.</typeparam>
        /// <returns>Instantiated repository with correct context.</returns>
        public TRepository GetRepository<TRepository>()
            where TRepository : IRepository
        {
            foreach (var repo in this.repositories)
            {
                if (repo is TRepository repository)
                {
                    return repository;
                }
            }
            throw new RepositoryNotFoundException(typeof(TRepository));
        }

        /// <summary>
        /// Open a new transaction and perform work using 
        /// this context. S
        /// </summary>
        /// <param name="action">Custom method for CRUD actions.</param>
        public void Transaction(Action<IUnitOfWork> action)
        {
            try
            {
                action(this);
                Save();
            }
            catch(Exception e)
            {
                //TODO: Implement logger.
            }
        }

        private void Save()
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
        private List<IRepository> repositories = new List<IRepository>();
    }
}
