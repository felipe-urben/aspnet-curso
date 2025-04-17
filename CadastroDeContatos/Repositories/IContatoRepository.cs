using System.Collections.Generic;
using CadastroDeContatos.Models;

namespace CadastroDeContatos.Repositories
{
    public interface IContatoRepository
    {
        List<ContatoModel> BuscarTodos();

        ContatoModel BuscarPorId(int Id);
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Editar(ContatoModel contato);
        void Apagar(int Id);
    }
}
