using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data
{
    public class ServicioData : IEntityTypeConfiguration<Servicio>
    {
        public void Configure(EntityTypeBuilder<Servicio> entityBuilder)
        {
            entityBuilder.HasData
            (
                new Servicio
                {
                    ServicioId = 1,
                    Nombre = "Wi-fi",
                    Descripción = "Internet a toda velocidad"
                },

                new Servicio
                {
                    ServicioId = 2,
                    Nombre = "Alimentos",
                    Descripción = "Servicio de comida"
                },

                new Servicio
                {
                    ServicioId = 3,
                    Nombre = "Aire Acondicionado",
                    Descripción = "Para viajar con la mayor comodidad posible"
                }
            );
        }
    }
}
