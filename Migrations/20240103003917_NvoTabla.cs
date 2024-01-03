using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla.Migrations
{
    /// <inheritdoc />
    public partial class NvoTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NumeroVillas",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    DetalleEspecial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumeroVillas", x => x.VillaNo);
                    table.ForeignKey(
                        name: "FK_NumeroVillas_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_NumeroVillas_VillaId",
                table: "NumeroVillas",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NumeroVillas");

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

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3000,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 1, 2, 21, 36, 58, 333, DateTimeKind.Local).AddTicks(260), new DateTime(2024, 1, 2, 21, 36, 58, 333, DateTimeKind.Local).AddTicks(260) });
        }
    }
}
