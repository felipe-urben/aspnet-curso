using CadastroDeContatos.Data;
using CadastroDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroDeContatos.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BancoContext _bancoContext;

        public UserRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public UserModel Adicionar(UserModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            _bancoContext.Usuario.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public void Apagar(int Id)
        {
            UserModel DBUser = BuscarPorId(Id) ?? throw new Exception("Houve um erro na exclusão do contato");

            _bancoContext.Usuario.Remove(DBUser);
            _bancoContext.SaveChanges();
        }

        public UserModel BuscarPorId(int Id)
        {
            return _bancoContext.Usuario.FirstOrDefault(x => x.Id == Id);
        }

        public List<UserModel> BuscarTodos()
        {
            return _bancoContext.Usuario.ToList();
        }
        
        public UserModel Editar(UserModel usuario)
        {
            UserModel DBUser = BuscarPorId(usuario.Id) ?? throw new Exception("Houve um erro na exclusão do contato");

            DBUser.Nome = usuario.Nome;
            DBUser.Login = usuario.Login;
            DBUser.Email = usuario.Email;
            DBUser.DataAtualizacao = DateTime.Now;

            return DBUser;
        }
    }
}
