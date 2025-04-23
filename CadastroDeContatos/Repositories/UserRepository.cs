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
            usuario.SetSenhaHash();
            _bancoContext.Usuario.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public UserModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
        {
            UserModel DBUser = BuscarPorId(alterarSenhaModel.Id) ?? throw new Exception("Houve um erro na atualização da senha, usuário não encontrado");

            if (!DBUser.SenhaValida(alterarSenhaModel.SenhaAtual)) throw new Exception("Senha atual não está correta");

            if (DBUser.SenhaValida(alterarSenhaModel.NovaSenha)) throw new Exception("Nova senha deve ser diferente da senha atual");

            if(alterarSenhaModel.ConfirmarNovaSenha != alterarSenhaModel.NovaSenha) throw new Exception("Senha nova diverge de 'Confirmar senha'");

            Console.WriteLine(alterarSenhaModel.ConfirmarNovaSenha);
            Console.WriteLine(alterarSenhaModel.NovaSenha);

            DBUser.SetNovaSenha(alterarSenhaModel.NovaSenha);
            DBUser.DataAtualizacao = DateTime.Now;
            _bancoContext.Usuario.Update(DBUser);
            _bancoContext.SaveChanges(); 
            
            return DBUser;
        }

        public void Apagar(int Id)
        {
            UserModel DBUser = BuscarPorId(Id) ?? throw new Exception("Houve um erro na exclusão do contato");

            _bancoContext.Usuario.Remove(DBUser);
            _bancoContext.SaveChanges();
        }

        public UserModel BuscarPorEmailLogin(string email, string login)
        {
            return _bancoContext.Usuario.FirstOrDefault(x => x.Email == email && x.Login == login);
        }

        public UserModel BuscarPorId(int Id)
        {
            return _bancoContext.Usuario.FirstOrDefault(x => x.Id == Id);
        }

        public UserModel BuscarPorLogin(string login)
        {
            return _bancoContext.Usuario.FirstOrDefault(x => x.Login == login);
        }

        public List<UserModel> BuscarTodos()
        {
            return _bancoContext.Usuario.ToList();
        }
        
        public UserModel Editar(UserModel usuario)
        {
            UserModel DBUser = BuscarPorId(usuario.Id) ?? throw new Exception("Houve um erro na edição do contato");

            DBUser.Nome = usuario.Nome;
            DBUser.Login = usuario.Login;
            DBUser.Email = usuario.Email;
            DBUser.Perfil = usuario.Perfil;
            DBUser.DataAtualizacao = DateTime.Now;

            _bancoContext.Usuario.Update(DBUser);
            _bancoContext.SaveChanges();
            return DBUser;
        }
    }
}
