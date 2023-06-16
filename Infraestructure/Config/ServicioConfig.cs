using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Config
{
    public class ServicioConfig : IEntityTypeConfiguration<Servicio>
    {
        public void Configure(EntityTypeBuilder<Servicio> entityBuilder)
        {
            entityBuilder.ToTable("Servicio");
            entityBuilder.HasKey(e => e.ServicioId);

            entityBuilder.HasMany(m => m.ViajeServicios)
            .WithOne(cm => cm.Servicio)
            .HasForeignKey(cm => cm.ServicioId);
        }
    }
}
