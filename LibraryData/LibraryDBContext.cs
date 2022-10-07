using LibraryDomain;
using Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ILogger = Logging.ILogger;

namespace LibraryData
{
    public class LibraryDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ILogger logger = new Logger();
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = LibraryManagement1Database")
                .LogTo(e => logger.LogOpration(e),
                    new[] { DbLoggerCategory.Database.Name },
                    LogLevel.Information
              )
        .EnableSensitiveDataLogging();
        }
    }
}