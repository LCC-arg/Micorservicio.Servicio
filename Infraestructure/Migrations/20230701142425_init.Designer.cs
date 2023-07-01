﻿// <auto-generated />
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(ServiciosContext))]
    [Migration("20230701142425_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Servicio", b =>
                {
                    b.Property<int>("ServicioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServicioId"));

                    b.Property<string>("Descripción")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServicioId");

                    b.ToTable("Servicio", (string)null);

                    b.HasData(
                        new
                        {
                            ServicioId = 1,
                            Descripción = "Internet a toda velocidad",
                            Nombre = "Wi-fi"
                        },
                        new
                        {
                            ServicioId = 2,
                            Descripción = "Servicio de comida",
                            Nombre = "Alimentos"
                        },
                        new
                        {
                            ServicioId = 3,
                            Descripción = "Para viajar con la mayor comodidad posible",
                            Nombre = "Aire Acondicionado"
                        });
                });

            modelBuilder.Entity("Domain.Entities.ViajeServicio", b =>
                {
                    b.Property<int>("ViajeServicioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ViajeServicioId"));

                    b.Property<int>("ServicioId")
                        .HasColumnType("int");

                    b.Property<int>("ViajeId")
                        .HasColumnType("int");

                    b.HasKey("ViajeServicioId");

                    b.HasIndex("ServicioId");

                    b.ToTable("ViajeServicio", (string)null);

                    b.HasData(
                        new
                        {
                            ViajeServicioId = 1,
                            ServicioId = 1,
                            ViajeId = 1
                        },
                        new
                        {
                            ViajeServicioId = 2,
                            ServicioId = 2,
                            ViajeId = 1
                        },
                        new
                        {
                            ViajeServicioId = 3,
                            ServicioId = 2,
                            ViajeId = 2
                        },
                        new
                        {
                            ViajeServicioId = 4,
                            ServicioId = 3,
                            ViajeId = 3
                        },
                        new
                        {
                            ViajeServicioId = 5,
                            ServicioId = 1,
                            ViajeId = 4
                        },
                        new
                        {
                            ViajeServicioId = 6,
                            ServicioId = 2,
                            ViajeId = 5
                        },
                        new
                        {
                            ViajeServicioId = 7,
                            ServicioId = 2,
                            ViajeId = 6
                        },
                        new
                        {
                            ViajeServicioId = 8,
                            ServicioId = 3,
                            ViajeId = 7
                        },
                        new
                        {
                            ViajeServicioId = 9,
                            ServicioId = 1,
                            ViajeId = 8
                        },
                        new
                        {
                            ViajeServicioId = 10,
                            ServicioId = 2,
                            ViajeId = 9
                        },
                        new
                        {
                            ViajeServicioId = 11,
                            ServicioId = 2,
                            ViajeId = 10
                        },
                        new
                        {
                            ViajeServicioId = 12,
                            ServicioId = 3,
                            ViajeId = 11
                        },
                        new
                        {
                            ViajeServicioId = 13,
                            ServicioId = 1,
                            ViajeId = 12
                        },
                        new
                        {
                            ViajeServicioId = 14,
                            ServicioId = 2,
                            ViajeId = 13
                        },
                        new
                        {
                            ViajeServicioId = 15,
                            ServicioId = 2,
                            ViajeId = 14
                        },
                        new
                        {
                            ViajeServicioId = 16,
                            ServicioId = 3,
                            ViajeId = 15
                        },
                        new
                        {
                            ViajeServicioId = 17,
                            ServicioId = 3,
                            ViajeId = 16
                        },
                        new
                        {
                            ViajeServicioId = 18,
                            ServicioId = 3,
                            ViajeId = 17
                        },
                        new
                        {
                            ViajeServicioId = 19,
                            ServicioId = 3,
                            ViajeId = 18
                        });
                });

            modelBuilder.Entity("Domain.Entities.ViajeServicio", b =>
                {
                    b.HasOne("Domain.Entities.Servicio", "Servicio")
                        .WithMany("ViajeServicios")
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("Domain.Entities.Servicio", b =>
                {
                    b.Navigation("ViajeServicios");
                });
#pragma warning restore 612, 618
        }
    }
}