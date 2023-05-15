using Domain.Entities;
using Infraestructure.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            modelBuilder.ApplyConfiguration(new ViajeServicioConfig());
        }
    }
}
