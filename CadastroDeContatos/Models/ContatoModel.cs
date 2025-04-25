using System.ComponentModel.DataAnnotations;

namespace CadastroDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Insira o nome do contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Insira o email do contato")]
        [EmailAddress(ErrorMessage ="Email inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Insira o celular do contato")]
        [Phone(ErrorMessage ="Número inválido")]
        public string Celular { get; set; }
        public int UsuarioId { get; set; }
        public UserModel Usuario { get; set; }
    }
}
