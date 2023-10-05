using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgoraEmbuGuacuAPI.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoRecuperaSenha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataExpiracaoTokenRedefinicaoSenha",
                table: "Usuarios",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TokenRedefinicaoSenha",
                table: "Usuarios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataExpiracaoTokenRedefinicaoSenha",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TokenRedefinicaoSenha",
                table: "Usuarios");
        }
    }
}
