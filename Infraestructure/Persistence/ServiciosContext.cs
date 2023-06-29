using Domain.Entities;
using Infraestructure.Config;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence
{
    public class ServiciosContext : DbContext
    {
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<ViajeServicio> ViajeServicios { get; set; }

        public ServiciosContext(DbContextOptions<ServiciosContext> options)
        : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ServicioConfig());
            modelBuilder.ApplyConfiguration(new ServicioData());

            modelBuilder.ApplyConfiguration(new ViajeServicioConfig());
            modelBuilder.ApplyConfiguration(new ViajeServicioData());
        }
    }
}
