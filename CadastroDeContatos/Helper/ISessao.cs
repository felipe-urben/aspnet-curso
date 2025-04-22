using CadastroDeContatos.Migrations;
using CadastroDeContatos.Models;

namespace CadastroDeContatos.Helper
{
    public interface ISessao
    {
        void CriarSessao(UserModel usuario);
        void RemoverSessao();
        UserModel BuscarSessao();
    }
}
