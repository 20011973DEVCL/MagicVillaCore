using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla.Migrations
{
    /// <inheritdoc />
    public partial class modifusu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 1, 3, 12, 54, 24, 361, DateTimeKind.Local).AddTicks(5930), new DateTime(2024, 1, 3, 12, 54, 24, 361, DateTimeKind.Local).AddTicks(5930) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 1, 3, 12, 54, 24, 361, DateTimeKind.Local).AddTicks(5850), new DateTime(2024, 1, 3, 12, 54, 24, 361, DateTimeKind.Local).AddTicks(5800) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 1, 3, 12, 54, 24, 361, DateTimeKind.Local).AddTicks(5860), new DateTime(2024, 1, 3, 12, 54, 24, 361, DateTimeKind.Local).AddTicks(5860) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 1, 3, 12, 54, 24, 361, DateTimeKind.Local).AddTicks(5860), new DateTime(2024, 1, 3, 12, 54, 24, 361, DateTimeKind.Local).AddTicks(5860) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3000,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 1, 3, 12, 54, 24, 361, DateTimeKind.Local).AddTicks(5870), new DateTime(2024, 1, 3, 12, 54, 24, 361, DateTimeKind.Local).AddTicks(5860) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 1, 3, 12, 52, 49, 260, DateTimeKind.Local).AddTicks(390), new DateTime(2024, 1, 3, 12, 52, 49, 260, DateTimeKind.Local).AddTicks(340) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 1, 3, 12, 52, 49, 260, DateTimeKind.Local).AddTicks(390), new DateTime(2024, 1, 3, 12, 52, 49, 260, DateTimeKind.Local).AddTicks(390) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 1, 3, 12, 52, 49, 260, DateTimeKind.Local).AddTicks(400), new DateTime(2024, 1, 3, 12, 52, 49, 260, DateTimeKind.Local).AddTicks(400) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3000,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 1, 3, 12, 52, 49, 260, DateTimeKind.Local).AddTicks(400), new DateTime(2024, 1, 3, 12, 52, 49, 260, DateTimeKind.Local).AddTicks(400) });
        }
    }
}
