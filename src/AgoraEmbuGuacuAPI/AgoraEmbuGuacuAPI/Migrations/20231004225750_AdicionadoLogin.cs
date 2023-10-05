using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgoraEmbuGuacuAPI.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTipoUsuario",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdTipoUsuario",
                table: "Usuarios",
                column: "IdTipoUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_TipoUsuario_IdTipoUsuario",
                table: "Usuarios",
                column: "IdTipoUsuario",
                principalTable: "TipoUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_TipoUsuario_IdTipoUsuario",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "TipoUsuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_IdTipoUsuario",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IdTipoUsuario",
                table: "Usuarios");
        }
    }
}
