using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla.Migrations
{
    /// <inheritdoc />
    public partial class modiftabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 1, 2, 21, 39, 17, 844, DateTimeKind.Local).AddTicks(7780), new DateTime(2024, 1, 2, 21, 39, 17, 844, DateTimeKind.Local).AddTicks(7650) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 1, 2, 21, 39, 17, 844, DateTimeKind.Local).AddTicks(7790), new DateTime(2024, 1, 2, 21, 39, 17, 844, DateTimeKind.Local).AddTicks(7780) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 1, 2, 21, 39, 17, 844, DateTimeKind.Local).AddTicks(7790), new DateTime(2024, 1, 2, 21, 39, 17, 844, DateTimeKind.Local).AddTicks(7790) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3000,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 1, 2, 21, 39, 17, 844, DateTimeKind.Local).AddTicks(7790), new DateTime(2024, 1, 2, 21, 39, 17, 844, DateTimeKind.Local).AddTicks(7790) });
        }
    }
}
