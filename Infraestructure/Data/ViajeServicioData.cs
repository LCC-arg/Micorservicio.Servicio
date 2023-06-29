using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class ViajeServicioData : IEntityTypeConfiguration<ViajeServicio>
    {
        public void Configure(EntityTypeBuilder<ViajeServicio> entityBuilder)
        {
            entityBuilder.HasData
            (
                new ViajeServicio
                {
                    ViajeServicioId = 1,
                    ViajeId = 1,
                    ServicioId = 1,
                },

                new ViajeServicio
                {
                    ViajeServicioId = 2,
                    ViajeId = 1,
                    ServicioId = 2,
                },

                new ViajeServicio
                {
                    ViajeServicioId = 3,
                    ViajeId = 2,
                    ServicioId = 2,
                },

                new ViajeServicio
                {
                    ViajeServicioId = 4,
                    ViajeId = 3,
                    ServicioId = 3,
                }
            );
        }
    }
}
