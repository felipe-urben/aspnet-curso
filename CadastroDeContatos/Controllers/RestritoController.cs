using CadastroDeContatos.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeContatos.Controllers
{
    public class RestritoController : Controller
    {
        [PaginaUserLogado]
        public IActionResult Index()
        {
            return View();
        }
    }
}
