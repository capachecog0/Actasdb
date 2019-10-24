using Microsoft.EntityFrameworkCore.Migrations;

namespace Db.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Pais = table.Column<string>(nullable: true),
                    NumeroDepartamento = table.Column<int>(nullable: false),
                    Provincia = table.Column<string>(nullable: true),
                    NumeroMunicipio = table.Column<int>(nullable: false),
                    Municipio = table.Column<string>(nullable: true),
                    Circunscripcion = table.Column<string>(nullable: true),
                    Localidad = table.Column<string>(nullable: true),
                    Recinto = table.Column<string>(nullable: true),
                    NumeroMesa = table.Column<int>(nullable: false),
                    CodigoMesa = table.Column<string>(nullable: true),
                    Eleccion = table.Column<string>(nullable: true),
                    Inscritos = table.Column<int>(nullable: false),
                    CC = table.Column<int>(nullable: false),
                    FPV = table.Column<int>(nullable: false),
                    MTS = table.Column<int>(nullable: false),
                    UCS = table.Column<int>(nullable: false),
                    MAS = table.Column<int>(nullable: false),
                    M21F = table.Column<int>(nullable: false),
                    PDC = table.Column<int>(nullable: false),
                    MNR = table.Column<int>(nullable: false),
                    PanBol = table.Column<int>(nullable: false),
                    Validos = table.Column<int>(nullable: false),
                    Blancos = table.Column<int>(nullable: false),
                    Nulos = table.Column<int>(nullable: false),
                    Computada = table.Column<string>(nullable: true),
                    Departamento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actas");
        }
    }
}
