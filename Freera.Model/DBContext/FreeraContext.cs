using Microsoft.EntityFrameworkCore;

namespace Freera.Model
{
    public class FreeraContext: DbContext
    {
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<WorkItemState> WorkItemStates { get; set; }

        public string DbPath { get; }

        /// <summary>
        /// TODO remove connection string from code.
        /// </summary>
        public FreeraContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "freera.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
    }
}
