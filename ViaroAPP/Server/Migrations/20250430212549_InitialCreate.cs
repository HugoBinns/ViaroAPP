using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ViaroAPP.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoAsiento = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Debito = table.Column<float>(type: "real", nullable: true),
                    Credito = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCalculo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCargo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SegundoNombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SalarioHora = table.Column<float>(type: "real", nullable: true),
                    IdCargo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Empleados_Cargos_IdCargo",
                        column: x => x.IdCargo,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Planillas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoEmpleado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    IdCalculo = table.Column<int>(type: "int", nullable: false),
                    FechaPlanilla = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HorasTrabajadas = table.Column<int>(type: "int", nullable: true),
                    Sobretiempo = table.Column<float>(type: "real", nullable: true),
                    PrimaProducción = table.Column<float>(type: "real", nullable: true),
                    TotalIngresos = table.Column<float>(type: "real", nullable: true),
                    DescuentoAcreedores = table.Column<float>(type: "real", nullable: true),
                    SeguroSocial = table.Column<float>(type: "real", nullable: true),
                    SeguroEducativo = table.Column<float>(type: "real", nullable: true),
                    Sinticop = table.Column<float>(type: "real", nullable: true),
                    DescuentoSeguro = table.Column<float>(type: "real", nullable: true),
                    ImpuestoSobreRenta = table.Column<float>(type: "real", nullable: true),
                    TotalDescuentos = table.Column<float>(type: "real", nullable: true),
                    Total = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planillas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planillas_Calculos_IdCalculo",
                        column: x => x.IdCalculo,
                        principalTable: "Calculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Planillas_Empleados_CodigoEmpleado",
                        column: x => x.CodigoEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Cedula",
                table: "Empleados",
                column: "Cedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_IdCargo",
                table: "Empleados",
                column: "IdCargo");

            migrationBuilder.CreateIndex(
                name: "IX_Planillas_CodigoEmpleado",
                table: "Planillas",
                column: "CodigoEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Planillas_IdCalculo",
                table: "Planillas",
                column: "IdCalculo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asientos");

            migrationBuilder.DropTable(
                name: "Planillas");

            migrationBuilder.DropTable(
                name: "Calculos");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Cargos");
        }
    }
}
