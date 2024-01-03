using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla.Migrations
{
    /// <inheritdoc />
    public partial class addusu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "Clave", "FechaActualizacion", "FechaCreacion", "NombreUsuario" },
                values: new object[] { 1, "123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Danilo Alarcon Lopez" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 1, 3, 12, 48, 11, 526, DateTimeKind.Local).AddTicks(2990), new DateTime(2024, 1, 3, 12, 48, 11, 526, DateTimeKind.Local).AddTicks(2960) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 1, 3, 12, 48, 11, 526, DateTimeKind.Local).AddTicks(2990), new DateTime(2024, 1, 3, 12, 48, 11, 526, DateTimeKind.Local).AddTicks(2990) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 1, 3, 12, 48, 11, 526, DateTimeKind.Local).AddTicks(3000), new DateTime(2024, 1, 3, 12, 48, 11, 526, DateTimeKind.Local).AddTicks(3000) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3000,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 1, 3, 12, 48, 11, 526, DateTimeKind.Local).AddTicks(3000), new DateTime(2024, 1, 3, 12, 48, 11, 526, DateTimeKind.Local).AddTicks(3000) });
        }
    }
}
