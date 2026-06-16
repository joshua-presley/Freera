namespace Freera.Interfaces
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Get a repository by type.
        /// </summary>
        /// <typeparam name="TRepository">Type of the repository object.</typeparam>
        /// <typeparam name="TModel">Type of the model object.</typeparam>
        /// <returns>Instantiated repository with correct context.</returns>
        TRepository GetRepository<TRepository>()
            where TRepository : IRepository;
        /// <summary>
        /// Open a new transaction and perform work using 
        /// this context. Saves at the end.
        /// </summary>
        /// <param name="action">Custom method for CRUD actions.</param>
        void Transaction(Action<IUnitOfWork> action);
    }
}
