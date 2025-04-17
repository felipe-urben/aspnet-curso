using System.Collections.Generic;
using CadastroDeContatos.Models;
using CadastroDeContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeContatos.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            List<UserModel> usuarios = _userRepository.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao(int Id)
        {
            UserModel usuario = _userRepository.BuscarPorId(Id);
            return View(usuario);
        }
        public IActionResult Editar(int Id)
        {
            UserModel usuario = _userRepository.BuscarPorId(Id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Criar(UserModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar o usuário: ${e.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.Apagar(id);
                    TempData["MensagemSucesso"] = "Usuario excluido com sucesso";
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível excluir o usuário: ${e.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(UserModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.Editar(usuario);
                    TempData["MensagemSucesso"] = "Contato editado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível Editar o usuário: ${e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
