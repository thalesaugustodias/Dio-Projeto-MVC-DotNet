using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dio_Projeto_MVC_DotNet.Context;
using Dio_Projeto_MVC_DotNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dio_Projeto_MVC_DotNet.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contatos = _context.Contatos.ToList();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            if (ModelState.IsValid)
            {
                _context.Contatos.Add(contato);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(contato);
        }

        public IActionResult Editar(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)

                return NotFound();

            return View(contato);
        }
        [HttpPost]
        public IActionResult Editar(Contato contato)
        {
            var contatoEditar = _context.Contatos.Find(contato.Id);
            if (contatoEditar == null)
            {
                return NotFound();
            }
            contatoEditar.Nome = contato.Nome;
            contatoEditar.Telefone = contato.Telefone;
            contatoEditar.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoEditar);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)

        {
            var contato = _context.Contatos.Find(id);
            if (contato == null)
                return RedirectToAction(nameof(Index));

            return View(contato);
        }

        public IActionResult Deletar(int id)
        {
            var contato = _context.Contatos.Find(id);

            if(contato == null)
                return NotFound();

            return View(contato);
        }

        [HttpPost]
        public IActionResult Deletar(Contato contato)
        {
            var contatoDb = _context.Contatos.Find(contato.Id);
            _context.Contatos.Remove(contatoDb);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}