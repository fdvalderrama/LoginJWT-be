using Microsoft.EntityFrameworkCore;

namespace LoginJWT_be
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Models.User> Users { get; set; }
    }
}
