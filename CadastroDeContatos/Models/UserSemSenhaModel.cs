using System;
using System.ComponentModel.DataAnnotations;
using CadastroDeContatos.Enums;

namespace CadastroDeContatos.Models
{
    public class UserSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Insira o nome do usuário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Insira o email do contato")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Insira o login do contato")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Insira o perfil do contato")]
        public PerfilEnum Perfil { get; set; }
    }
}
