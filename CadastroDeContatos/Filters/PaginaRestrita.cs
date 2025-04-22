using CadastroDeContatos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace CadastroDeContatos.Filters
{
    public class PaginaRestrita : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessao = context.HttpContext.Session.GetString("UsuarioLogado");

            if (string.IsNullOrEmpty(sessao))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }
            else
            {
                UserModel usuario = JsonConvert.DeserializeObject<UserModel>(sessao);

                if(usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }

                if (usuario.Perfil != Enums.PerfilEnum.Admin)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Restrito" }, { "action", "Index" } });
                }
            }
                base.OnActionExecuting(context);
        }
    }
}
