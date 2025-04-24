using System.Collections.Generic;
using CadastroDeContatos.Filters;
using CadastroDeContatos.Helper;
using CadastroDeContatos.Models;
using CadastroDeContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeContatos.Controllers
{
    [PaginaUserLogado]
    public class ContatoController : Controller
    {

        private readonly IContatoRepository _contatoRepository;
        private readonly ISessao _sessao;

        public ContatoController(IContatoRepository contatoRepository, ISessao sessao)
        {
            _contatoRepository = contatoRepository;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            UserModel usuario = _sessao.BuscarSessao();
            List<ContatoModel> contatos = _contatoRepository.BuscarTodos(usuario.Id);
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int Id)
        {
            var contato = _contatoRepository.BuscarPorId(Id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int Id)
        {
            var contato = _contatoRepository.BuscarPorId(Id);
            return View(contato);
        }

        public IActionResult Apagar(int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Apagar(Id);
                    TempData["MensagemSucesso"] = "Contato excluido com sucesso";
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível excluir o contato: ${e.Message}";
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel usuario = _sessao.BuscarSessao();
                    contato.UsuarioId = usuario.Id;
                    _contatoRepository.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato salvo com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch(System.Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar o contato: ${e.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Editar(contato);
                    TempData["MensagemSucesso"] = "Contato editado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch(System.Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível Editar o usuário: ${e.Message}";
                return RedirectToAction("Index");
            }
            
        }


    }
}
