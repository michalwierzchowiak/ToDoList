using Microsoft.EntityFrameworkCore;
using Shared;

namespace Server
{
    public class DatabaseAppContext : DbContext
    {
        public DatabaseAppContext(DbContextOptions<DatabaseAppContext> options) : base(options) { }
        public DbSet<TodoEntry> TodoEntries { get; set; }
    }
}
