using CadastroDeContatos.Models;

namespace CadastroDeContatos.Repositories
{
    public interface IContatoRepository
    {
        ContatoModel Adicionar(ContatoModel contato);
    }
}
