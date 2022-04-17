using KTX_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace KTX_MVC.Context
{
    public class MVCContext : DbContext
    {
        public MVCContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Students> Students { get; set; }

        public DbSet<Parrents> Parrents { get; set; }
    }
}
