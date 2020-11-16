using Microsoft.EntityFrameworkCore;
using Moradia.Data.Model;

namespace Moradia.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Condominio> Condominio { get; set; }
        public virtual DbSet<Familia> Familia { get; set; }
        public virtual DbSet<Morador> Morador { get; set; }

    }
}
