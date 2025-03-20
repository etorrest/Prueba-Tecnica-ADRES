using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdquisicionesADRES.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoAdquisicion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoAdquisicion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoAdquisicion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAdquisicion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadResponsable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadResponsable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adquisicion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoAdquisicionId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ValorUnitarios = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Presupuesto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnidadResponsableId = table.Column<int>(type: "int", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    FechaAdquisicion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoAdquisicionId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adquisicion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adquisicion_EstadoAdquisicion_EstadoAdquisicionId",
                        column: x => x.EstadoAdquisicionId,
                        principalTable: "EstadoAdquisicion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adquisicion_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adquisicion_TipoAdquisicion_TipoAdquisicionId",
                        column: x => x.TipoAdquisicionId,
                        principalTable: "TipoAdquisicion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adquisicion_UnidadResponsable_UnidadResponsableId",
                        column: x => x.UnidadResponsableId,
                        principalTable: "UnidadResponsable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adquisicion_EstadoAdquisicionId",
                table: "Adquisicion",
                column: "EstadoAdquisicionId");

            migrationBuilder.CreateIndex(
                name: "IX_Adquisicion_ProveedorId",
                table: "Adquisicion",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Adquisicion_TipoAdquisicionId",
                table: "Adquisicion",
                column: "TipoAdquisicionId");

            migrationBuilder.CreateIndex(
                name: "IX_Adquisicion_UnidadResponsableId",
                table: "Adquisicion",
                column: "UnidadResponsableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adquisicion");

            migrationBuilder.DropTable(
                name: "EstadoAdquisicion");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "TipoAdquisicion");

            migrationBuilder.DropTable(
                name: "UnidadResponsable");
        }
    }
}
