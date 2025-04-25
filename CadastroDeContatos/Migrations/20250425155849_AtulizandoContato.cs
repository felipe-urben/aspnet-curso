using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroDeContatos.Migrations
{
    public partial class AtulizandoContato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contato_Usuario_UsuarioId",
                table: "Contato");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Contato",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Contato",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "celular",
                table: "Contato",
                newName: "Celular");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Contato",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_Usuario_UsuarioId",
                table: "Contato",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contato_Usuario_UsuarioId",
                table: "Contato");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Contato",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Contato",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Celular",
                table: "Contato",
                newName: "celular");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Contato",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_Usuario_UsuarioId",
                table: "Contato",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
