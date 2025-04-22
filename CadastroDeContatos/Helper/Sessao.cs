using Newtonsoft.Json;
using CadastroDeContatos.Models;
using Microsoft.AspNetCore.Http;

namespace CadastroDeContatos.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public UserModel BuscarSessao()
        {
            string sessao = _httpContext.HttpContext.Session.GetString("UsuarioLogado");

            if (string.IsNullOrEmpty(sessao)) return null;
            
            return JsonConvert.DeserializeObject<UserModel>(sessao);
        }

        public void CriarSessao(UserModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _httpContext.HttpContext.Session.SetString("UsuarioLogado", valor);
        }

        public void RemoverSessao()
        {
            _httpContext.HttpContext.Session.Remove("UsuarioLogado");
        }
    }
}
