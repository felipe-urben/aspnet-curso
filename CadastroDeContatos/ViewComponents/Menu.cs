using System.Threading.Tasks;
using CadastroDeContatos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CadastroDeContatos.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessao = HttpContext.Session.GetString("UsuarioLogado");

            if (string.IsNullOrEmpty(sessao)) return null;

            UserModel usuario = JsonConvert.DeserializeObject<UserModel>(sessao);
            return View(usuario);
        }
    }
}
