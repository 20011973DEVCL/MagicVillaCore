using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla.Migrations
{
    /// <inheritdoc />
    public partial class NvoRegistro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 1, 2, 21, 36, 58, 333, DateTimeKind.Local).AddTicks(240), new DateTime(2024, 1, 2, 21, 36, 58, 333, DateTimeKind.Local).AddTicks(220) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 1, 2, 21, 36, 58, 333, DateTimeKind.Local).AddTicks(250), new DateTime(2024, 1, 2, 21, 36, 58, 333, DateTimeKind.Local).AddTicks(250) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 1, 2, 21, 36, 58, 333, DateTimeKind.Local).AddTicks(250), new DateTime(2024, 1, 2, 21, 36, 58, 333, DateTimeKind.Local).AddTicks(250) });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenUrl", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[] { 3000, "", "Culiando a la Fernanda todo el Dia", new DateTime(2024, 1, 2, 21, 36, 58, 333, DateTimeKind.Local).AddTicks(260), new DateTime(2024, 1, 2, 21, 36, 58, 333, DateTimeKind.Local).AddTicks(260), "", 100, "Villa Danilo y Fernanda", 7, 500.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3000);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 12, 27, 10, 29, 17, 435, DateTimeKind.Local).AddTicks(3780), new DateTime(2023, 12, 27, 10, 29, 17, 435, DateTimeKind.Local).AddTicks(3740) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 12, 27, 10, 29, 17, 435, DateTimeKind.Local).AddTicks(3790), new DateTime(2023, 12, 27, 10, 29, 17, 435, DateTimeKind.Local).AddTicks(3790) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 12, 27, 10, 29, 17, 435, DateTimeKind.Local).AddTicks(3790), new DateTime(2023, 12, 27, 10, 29, 17, 435, DateTimeKind.Local).AddTicks(3790) });
        }
    }
}
