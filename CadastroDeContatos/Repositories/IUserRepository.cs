using CadastroDeContatos.Models;
using System.Collections.Generic;

namespace CadastroDeContatos.Repositories
{
    public interface IUserRepository
    {
        List<UserModel> BuscarTodos();
        UserModel BuscarPorId(int Id);
        UserModel Adicionar(UserModel usuario);
        UserModel Editar(UserModel usuario);
        void Apagar(int Id);
    }
}
