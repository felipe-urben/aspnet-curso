using System;
using System.ComponentModel.DataAnnotations;
using CadastroDeContatos.Enums;
using CadastroDeContatos.Helper;

namespace CadastroDeContatos.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Insira o nome do usuário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Insira o email do usuário")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Insira o login do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Insira o perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }
        [Required(ErrorMessage = "Insira a senha do usuário")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }
    }
}
