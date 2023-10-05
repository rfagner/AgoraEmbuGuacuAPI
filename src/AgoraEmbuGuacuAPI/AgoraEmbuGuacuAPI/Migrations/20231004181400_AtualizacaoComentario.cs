using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgoraEmbuGuacuAPI.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoComentario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Denuncias_DenunciaId",
                table: "Comentarios");

            migrationBuilder.AlterColumn<int>(
                name: "DenunciaId",
                table: "Comentarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DenunciaId1",
                table: "Comentarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_DenunciaId1",
                table: "Comentarios",
                column: "DenunciaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Denuncias_DenunciaId",
                table: "Comentarios",
                column: "DenunciaId",
                principalTable: "Denuncias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Denuncias_DenunciaId1",
                table: "Comentarios",
                column: "DenunciaId1",
                principalTable: "Denuncias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Denuncias_DenunciaId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Denuncias_DenunciaId1",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_DenunciaId1",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "DenunciaId1",
                table: "Comentarios");

            migrationBuilder.AlterColumn<int>(
                name: "DenunciaId",
                table: "Comentarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Denuncias_DenunciaId",
                table: "Comentarios",
                column: "DenunciaId",
                principalTable: "Denuncias",
                principalColumn: "Id");
        }
    }
}
