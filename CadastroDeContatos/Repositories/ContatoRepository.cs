using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CadastroDeContatos.Data;
using CadastroDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeContatos.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public List<ContatoModel> BuscarTodos(int UsuarioId)
        {
            /*string query = "SELECT * FROM Contato WHERE UsuarioId = @UsuarioId";

            var parameter = new Microsoft.Data.SqlClient.SqlParameter("@UsuarioId", UsuarioId);

            return _bancoContext.Contato.FromSqlRaw(query, parameter).ToList();*/
            Console.WriteLine(UsuarioId);
            return _bancoContext.Contato.Where(x => x.UsuarioId.Equals(UsuarioId)).ToList(); 
        }
        public List<int> BuscarIds()
        {
            return _bancoContext.Contato.Select(x => x.UsuarioId).ToList();
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

            DBContato.Nome = contato.Nome;
            DBContato.Email = contato.Email;
            DBContato.Celular = contato.Celular;

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
