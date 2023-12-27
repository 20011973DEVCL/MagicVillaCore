using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla.Migrations
{
    /// <inheritdoc />
    public partial class AgregarDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenUrl", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { 1, "", "Tiene las tremendas Tetas", new DateTime(2023, 12, 27, 10, 29, 17, 435, DateTimeKind.Local).AddTicks(3780), new DateTime(2023, 12, 27, 10, 29, 17, 435, DateTimeKind.Local).AddTicks(3740), "", 50, "Villa Fernanda", 5, 200.0 },
                    { 2, "", "Tiene una Cintura y un Culo", new DateTime(2023, 12, 27, 10, 29, 17, 435, DateTimeKind.Local).AddTicks(3790), new DateTime(2023, 12, 27, 10, 29, 17, 435, DateTimeKind.Local).AddTicks(3790), "", 70, "Villa Maira", 7, 300.0 },
                    { 3, "", "No se a cual de las 2 me Culiaria Primero", new DateTime(2023, 12, 27, 10, 29, 17, 435, DateTimeKind.Local).AddTicks(3790), new DateTime(2023, 12, 27, 10, 29, 17, 435, DateTimeKind.Local).AddTicks(3790), "", 100, "Villa Fernanda y Maira", 7, 500.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
