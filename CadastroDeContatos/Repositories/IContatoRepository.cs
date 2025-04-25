using System.Collections.Generic;
using CadastroDeContatos.Models;

namespace CadastroDeContatos.Repositories
{
    public interface IContatoRepository
    {
        List<ContatoModel> BuscarTodos(int UsuarioId);
        List<int> BuscarIds();
        ContatoModel BuscarPorId(int Id);
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Editar(ContatoModel contato);
        void Apagar(int Id);
    }
}
