using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace L01__2018_RR_604___BLOG_.Models
{
    public class blogContext :DbContext
    {
        public blogContext(DbContextOptions<blogContext> options): base(options)
        { 

        }

        public DbSet<usuario> usuario{ get; set; }

        public DbSet<comentarios> comentarios{ get; set; }

        public DbSet<publicaciones> publicaciones { get; set; }
    }
}
