using CadastroDeContatos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace CadastroDeContatos.Filters
{
    public class PaginaUserLogado : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessao = context.HttpContext.Session.GetString("UsuarioLogado");

            if (string.IsNullOrEmpty(sessao))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "login" }, { "action", "Index" } });
            }
            else
            {
                UserModel usuario = JsonConvert.DeserializeObject<UserModel>(sessao);

                if(usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "login" }, { "action", "Index" } });
                }
            }
                base.OnActionExecuting(context);
        }
    }
}
