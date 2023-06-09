﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    ServicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripción = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.ServicioId);
                });

            migrationBuilder.CreateTable(
                name: "ViajeServicio",
                columns: table => new
                {
                    ViajeServicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViajeId = table.Column<int>(type: "int", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViajeServicio", x => x.ViajeServicioId);
                    table.ForeignKey(
                        name: "FK_ViajeServicio_Servicio_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicio",
                        principalColumn: "ServicioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Servicio",
                columns: new[] { "ServicioId", "Descripción", "Nombre" },
                values: new object[,]
                {
                    { 1, "Internet a toda velocidad", "Wi-fi" },
                    { 2, "Servicio de comida", "Alimentos" },
                    { 3, "Para viajar con la mayor comodidad posible", "Aire Acondicionado" }
                });

            migrationBuilder.InsertData(
                table: "ViajeServicio",
                columns: new[] { "ViajeServicioId", "ServicioId", "ViajeId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 2, 2 },
                    { 4, 3, 3 },
                    { 5, 1, 4 },
                    { 6, 2, 5 },
                    { 7, 2, 6 },
                    { 8, 3, 7 },
                    { 9, 1, 8 },
                    { 10, 2, 9 },
                    { 11, 2, 10 },
                    { 12, 3, 11 },
                    { 13, 1, 12 },
                    { 14, 2, 13 },
                    { 15, 2, 14 },
                    { 16, 3, 15 },
                    { 17, 3, 16 },
                    { 18, 3, 17 },
                    { 19, 3, 18 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ViajeServicio_ServicioId",
                table: "ViajeServicio",
                column: "ServicioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ViajeServicio");

            migrationBuilder.DropTable(
                name: "Servicio");
        }
    }
}
