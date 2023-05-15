using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Config
{
    public class ViajeServicioConfig : IEntityTypeConfiguration<ViajeServicio>
    {
        public void Configure(EntityTypeBuilder<ViajeServicio> entityBuilder)
        {
            entityBuilder.ToTable("ViajeServicio");
            entityBuilder.HasKey(e => e.ViajeServicioId);

            entityBuilder.Property(m => m.ViajeServicioId).ValueGeneratedOnAdd();

        }

    }
}
