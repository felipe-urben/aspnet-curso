using System;
using CadastroDeContatos.Helper;
using CadastroDeContatos.Models;
using CadastroDeContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeContatos.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessao _sessao;
        public AlterarSenhaController(IUserRepository userRepository, ISessao sessao)
        {
            _userRepository = userRepository;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel)
        {
            try
            {

                UserModel usuario = _sessao.BuscarSessao();
                alterarSenhaModel.Id = usuario.Id;

                if (ModelState.IsValid)
                {
                    _userRepository.AlterarSenha(alterarSenhaModel);
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
                    _sessao.RemoverSessao();
                    return RedirectToAction("Index", "Login");
                }
                return View("Index", alterarSenhaModel);
            }
            catch(Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível redefinir sua senha, por favor verifique os campos enviados, detalhe do erro: {e.Message}";
                return View("Index", alterarSenhaModel);
            }
        }
    }
}
