using Microsoft.EntityFrameworkCore;
using App_TecnoGlass.Models;

namespace App_TecnoGlass
{
    public class AplicationDbContext: DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Ordenes> Ordenes { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<Productos> Productos { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> option):base(option)
        {

        }
    }
}
