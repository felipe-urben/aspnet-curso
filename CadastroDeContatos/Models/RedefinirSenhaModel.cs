using System.ComponentModel.DataAnnotations;

namespace CadastroDeContatos.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Insira o email do usuário")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Insira o login do usuário")]
        public string Login { get; set; }
    }
}
