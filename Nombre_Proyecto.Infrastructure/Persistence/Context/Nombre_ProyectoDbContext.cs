using Microsoft.EntityFrameworkCore;
using Nombre_Proyecto.Infrastructure.Persistence.Configuration.Table;

namespace Nombre_Proyecto.Infrastructure.Persistence.Adapters
{
    public class Nombre_ProyectoDbContext : DbContext
    {
        public Nombre_ProyectoDbContext(DbContextOptions<Nombre_ProyectoDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersConfigurations());

            base.OnModelCreating(modelBuilder);
        }
    }
}