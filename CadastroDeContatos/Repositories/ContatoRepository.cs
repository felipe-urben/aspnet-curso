using System.Collections.Generic;
using System.Data;
using System.Linq;
using CadastroDeContatos.Data;
using CadastroDeContatos.Models;

namespace CadastroDeContatos.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contato.ToList();
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contato.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public ContatoModel BuscarPorId(int Id)
        {
            return _bancoContext.Contato.FirstOrDefault(x => x.Id == Id);
        }

        public ContatoModel Editar(ContatoModel contato)
        {
            ContatoModel DBContato = BuscarPorId(contato.Id) ?? throw new System.Exception("Houve um erro na atualização do contato");

            DBContato.nome = contato.nome;
            DBContato.email = contato.email;
            DBContato.celular = contato.celular;

            _bancoContext.Contato.Update(DBContato);
            _bancoContext.SaveChanges();
            return DBContato;
        }

        public void Apagar(int Id)
        {
            var DBcontato = BuscarPorId(Id) ?? throw new System.Exception("Houve um erro na exclusão do contato");

            _bancoContext.Contato.Remove(DBcontato);
            _bancoContext.SaveChanges();
        }
    }
}
