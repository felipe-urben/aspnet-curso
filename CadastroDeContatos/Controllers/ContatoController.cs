using System.Collections.Generic;
using CadastroDeContatos.Models;
using CadastroDeContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeContatos.Controllers
{
    public class ContatoController : Controller
    {

        private readonly IContatoRepository _contatoRepository;

        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepository.BuscarTodos();
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
