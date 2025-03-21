using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    Nombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoAdquisicion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modulo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    Icono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Enlace = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nit = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
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
                    Nombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
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
                    Nombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
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
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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

            migrationBuilder.InsertData(
                table: "EstadoAdquisicion",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Creada" },
                    { 2, "En Ejecucion" },
                    { 3, "Finalizada" },
                    { 4, "Cancelada" }
                });

            migrationBuilder.InsertData(
                table: "Modulo",
                columns: new[] { "Id", "Descripcion", "Enlace", "Icono", "Orden", "Titulo" },
                values: new object[,]
                {
                    { new Guid("64ac3033-266b-424a-99fa-1127b29828fe"), "Permite la consulta, adición y actualización de proveedores.", "/proveedores", "proveedor.png", 2, "PROVEEDORES" },
                    { new Guid("91e8fa40-74be-4aac-b886-c463d86f9eea"), "Permite el mantenimiento de tablas de referencia (crear y modificar) ", "/ajustes", "ajustes.png", 3, "MANTENIMIENTO DE TABLAS" },
                    { new Guid("965fb6a6-6ec6-4908-a130-5a85cda98d97"), "Permite la gestión integral de registro de solicitudes de adquisiciones", "/adquisiciones", "recibir.png", 1, "ADQUISICIONES" }
                });

            migrationBuilder.InsertData(
                table: "Proveedor",
                columns: new[] { "Id", "Nit", "Nombre" },
                values: new object[,]
                {
                    { 1, "900500234-1", "Laboratorios Bayer S.A." },
                    { 2, "900495029-1", "Laboratorio  Bioprocesos Colombia" },
                    { 3, "900395923-1", "Dispensador MEDIMAX" }
                });

            migrationBuilder.InsertData(
                table: "TipoAdquisicion",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Bienes" },
                    { 2, "Servicios" },
                    { 3, "Obras" }
                });

            migrationBuilder.InsertData(
                table: "UnidadResponsable",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Subdireccion Financiera" },
                    { 2, "Dirección de Medicamentos y Tecnologías en Salud " },
                    { 3, "Subdireccion Administrativa" }
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
                name: "Modulo");

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
