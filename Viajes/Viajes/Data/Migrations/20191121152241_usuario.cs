using Microsoft.EntityFrameworkCore.Migrations;

namespace Viajes.Data.Migrations
{
    public partial class usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Planes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Planes_UsuarioId",
                table: "Planes",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Planes_AspNetUsers_UsuarioId",
                table: "Planes",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planes_AspNetUsers_UsuarioId",
                table: "Planes");

            migrationBuilder.DropIndex(
                name: "IX_Planes_UsuarioId",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Planes");
        }
    }
}
