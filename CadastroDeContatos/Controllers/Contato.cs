using Microsoft.AspNetCore.Mvc;

namespace CadastroDeContatos.Controllers
{
    public class Contato : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
