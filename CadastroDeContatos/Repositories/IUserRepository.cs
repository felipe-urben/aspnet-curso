using CadastroDeContatos.Models;
using System.Collections.Generic;

namespace CadastroDeContatos.Repositories
{
    public interface IUserRepository
    {
        UserModel BuscarPorEmailLogin(string email, string login);
        UserModel BuscarPorLogin(string login);
        List<UserModel> BuscarTodos();
        UserModel BuscarPorId(int Id);
        UserModel Adicionar(UserModel usuario);
        UserModel Editar(UserModel usuario);
        void Apagar(int Id);
    }
}
