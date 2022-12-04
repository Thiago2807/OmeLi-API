using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmeLi.Migrations
{
    public partial class MicracaoValoresPadroes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StatusLivros",
                columns: new[] { "StatusLivroId", "DescStatusLivroId" },
                values: new object[,]
                {
                    { 1, "Default" },
                    { 2, "Ativo" },
                    { 3, "Desativado" },
                    { 4, "Emprestado" }
                });

            migrationBuilder.InsertData(
                table: "TiposTelefones",
                columns: new[] { "TipoTelefoneId", "DescTipoTelefone" },
                values: new object[,]
                {
                    { 1, "Celular" },
                    { 2, "Residencial" },
                    { 3, "Comercial" },
                    { 4, "Recado" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StatusLivros",
                keyColumn: "StatusLivroId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StatusLivros",
                keyColumn: "StatusLivroId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StatusLivros",
                keyColumn: "StatusLivroId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StatusLivros",
                keyColumn: "StatusLivroId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TiposTelefones",
                keyColumn: "TipoTelefoneId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TiposTelefones",
                keyColumn: "TipoTelefoneId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TiposTelefones",
                keyColumn: "TipoTelefoneId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TiposTelefones",
                keyColumn: "TipoTelefoneId",
                keyValue: 4);
        }
    }
}
