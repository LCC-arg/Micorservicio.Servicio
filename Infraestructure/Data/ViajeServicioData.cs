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
                },
                new ViajeServicio
                {
                    ViajeServicioId = 5,
                    ViajeId = 4,
                    ServicioId = 1,
                },

                new ViajeServicio
                {
                    ViajeServicioId = 6,
                    ViajeId = 5,
                    ServicioId = 2,
                },

                new ViajeServicio
                {
                    ViajeServicioId = 7,
                    ViajeId = 6,
                    ServicioId = 2,
                },

                new ViajeServicio
                {
                    ViajeServicioId = 8,
                    ViajeId = 7,
                    ServicioId = 3,
                },
                new ViajeServicio
                {
                    ViajeServicioId = 9,
                    ViajeId = 8,
                    ServicioId = 1,
                },

                new ViajeServicio
                {
                    ViajeServicioId = 10,
                    ViajeId = 9,
                    ServicioId = 2,
                },

                new ViajeServicio
                {
                    ViajeServicioId = 11,
                    ViajeId = 10,
                    ServicioId = 2,
                },

                new ViajeServicio
                {
                    ViajeServicioId = 12,
                    ViajeId = 11,
                    ServicioId = 3,
                },
                new ViajeServicio
                {
                    ViajeServicioId = 13,
                    ViajeId = 12,
                    ServicioId = 1,
                },

                new ViajeServicio
                {
                    ViajeServicioId = 14,
                    ViajeId = 13,
                    ServicioId = 2,
                },

                new ViajeServicio
                {
                    ViajeServicioId = 15,
                    ViajeId = 14,
                    ServicioId = 2,
                },

                new ViajeServicio
                {
                    ViajeServicioId = 16,
                    ViajeId = 15,
                    ServicioId = 3,
                },

                new ViajeServicio
                {
                    ViajeServicioId = 17,
                    ViajeId = 16,
                    ServicioId = 3,
                },

                new ViajeServicio
                {
                    ViajeServicioId = 18,
                    ViajeId = 17,
                    ServicioId = 3,
                },

                new ViajeServicio
                {
                    ViajeServicioId = 19,
                    ViajeId = 18,
                    ServicioId = 3,
                }
            );
        }
    }
}
