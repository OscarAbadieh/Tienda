using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTienda
{
    public class Contexto : DbContext

    {
        public Contexto() : base("Tienda de Ropa")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }


    }
}
