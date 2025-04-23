using System;
using CadastroDeContatos.Helper;
using CadastroDeContatos.Models;
using CadastroDeContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessao _sessao;

        public LoginController(IUserRepository userRepository, ISessao sessao) 
        {
            _userRepository = userRepository;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            if(_sessao.BuscarSessao() != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessao();
            return RedirectToAction("Index", "Login");
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel usuario = _userRepository.BuscarPorLogin(loginModel.Login);
                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessao(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = "Senha inválida, tente novamente";
                    }
                    TempData["MensagemErro"] = "Usuário e/ou senha inválidos";
                }
                return View("Index", loginModel);
            }
            catch(Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível realizar o login: ${e.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EnviarLinkRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel usuario = _userRepository.BuscarPorEmailLogin(redefinirSenhaModel.Email, redefinirSenhaModel.Login);
                    if (usuario != null)
                    {
                        TempData["MensagemSucesso"] = $"Enviamos um e-mail de confirmação para {usuario.Email}";
                        return RedirectToAction("Index", "Login");
                    }
                    TempData["MensagemErro"] = "Não foi possível redefinir sua senha, por favor verifique o login e e-mail";
                    return View("Index");
                }
                return View("RedefinirSenha");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível redefinir sua senha: ${e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
