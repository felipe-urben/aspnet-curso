using System.ComponentModel.DataAnnotations;

namespace CadastroDeContatos.Models
{
    public class AlterarSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Insira a senha atual")]
        public string SenhaAtual { get; set; }
        [Required(ErrorMessage = "Insira a nova senha")]
        public string NovaSenha { get; set; }
        [Required(ErrorMessage = "Insira a confirmação")]
        [Compare("NovaSenha", ErrorMessage = "As senhas divergem")]
        public string ConfirmarNovaSenha { get; set; }

    }
}
