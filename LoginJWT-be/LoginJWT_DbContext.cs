using LoginJWT_be.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginJWT_be
{
    public class LoginJWT_DbContext : DbContext
    {
        public LoginJWT_DbContext(DbContextOptions<LoginJWT_DbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
