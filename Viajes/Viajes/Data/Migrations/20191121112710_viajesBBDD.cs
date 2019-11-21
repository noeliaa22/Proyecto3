using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Viajes.Data.Migrations
{
    public partial class viajesBBDD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "AspNetUsers",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "AspNetUsers",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreUsuario",
                table: "AspNetUsers",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Intinerarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<string>(nullable: true),
                    CantidadValoraciones = table.Column<int>(nullable: false),
                    ValoracionMedia = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intinerarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Intinerarios_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false),
                    Imagen = table.Column<string>(nullable: true),
                    Continente = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ValoracionIntinerarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<string>(nullable: true),
                    IntinerarioId = table.Column<int>(nullable: true),
                    Puntuacion = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValoracionIntinerarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValoracionIntinerarios_Intinerarios_IntinerarioId",
                        column: x => x.IntinerarioId,
                        principalTable: "Intinerarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ValoracionIntinerarios_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Imagen = table.Column<string>(nullable: true),
                    Video = table.Column<string>(nullable: true),
                    PaisId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ciudades_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(maxLength: 40, nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    Imagen = table.Column<string>(nullable: true),
                    Revisado = table.Column<bool>(nullable: false),
                    FechaPublicacion = table.Column<DateTime>(nullable: true),
                    ValoracionMedia = table.Column<double>(nullable: true),
                    CantidadValoraciones = table.Column<int>(nullable: false),
                    CiudadId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planes_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanIntinerarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanId = table.Column<int>(nullable: true),
                    IntinerarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanIntinerarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanIntinerarios_Intinerarios_IntinerarioId",
                        column: x => x.IntinerarioId,
                        principalTable: "Intinerarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanIntinerarios_Planes_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Planes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Valoraciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Puntuacion = table.Column<int>(nullable: false),
                    PlanId = table.Column<int>(nullable: true),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valoraciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Valoraciones_Planes_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Planes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Valoraciones_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_PaisId",
                table: "Ciudades",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Intinerarios_UsuarioId",
                table: "Intinerarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Planes_CiudadId",
                table: "Planes",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanIntinerarios_IntinerarioId",
                table: "PlanIntinerarios",
                column: "IntinerarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanIntinerarios_PlanId",
                table: "PlanIntinerarios",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Valoraciones_PlanId",
                table: "Valoraciones",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Valoraciones_UsuarioId",
                table: "Valoraciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ValoracionIntinerarios_IntinerarioId",
                table: "ValoracionIntinerarios",
                column: "IntinerarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ValoracionIntinerarios_UsuarioId",
                table: "ValoracionIntinerarios",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanIntinerarios");

            migrationBuilder.DropTable(
                name: "Valoraciones");

            migrationBuilder.DropTable(
                name: "ValoracionIntinerarios");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "Intinerarios");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NombreUsuario",
                table: "AspNetUsers");
        }
    }
}
