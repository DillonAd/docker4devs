using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace api
{
    public class ValueContext : DbContext
    {
        public DbSet<Value> Values { get; set; }

        public ValueContext(DbContextOptions<ValueContext> options) : base(options) { }
    }
}