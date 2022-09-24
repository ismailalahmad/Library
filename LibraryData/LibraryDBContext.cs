using LibraryDomain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace LibraryData
{
    public class LibraryDBContext : DbContext
    {
        public DbSet<User> MyProperty { get; set; }
    }
}