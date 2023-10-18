using Avaliacoes.Domain;
using Avaliacoes.Models;
using Avaliacoes.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Avaliacoes.Controllers
{
    [Authorize]
    public class AvaliacoesController : Controller
    {
        private readonly AvaliacaoDbContext _context;
        private readonly IConfiguration _configuration;

        public AvaliacoesController(AvaliacaoDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var username = HttpContext.User.Identity.Name;
            var usuario = _context.Usuario.Where(u => u.Email == username).FirstOrDefault();

            if (usuario.Admin == 1)
                return View(await (from a in _context.Avaliacao
                                   join b in _context.Usuario on a.UsuarioId equals b.UsuarioId
                                   join c in _context.Divisao on a.DivisaoId equals c.DivisaoId
                                   where a.Exibir == true
                                   orderby a.DivisaoId ascending
                                   select new AvaliacaoViewModel
                                   {
                                       AvaliacaoId = a.AvaliacaoId,
                                       Divisao = c.Nome,
                                       Nome = a.Nome,
                                       DataPP = a.DataPP,
                                       DataMeio = a.DataMeio,
                                       DataFull = a.DataFull,
                                       Acoes = a.Acoes,
                                       Avaliador = b.Nome,
                                       Bondes = a.Bondes,
                                       Contencao = a.Contencao,
                                       Dedicacao = a.Dedicacao,
                                       Estudos = a.Estudos,
                                       Financeiro = a.Financeiro,
                                       Frequencia = a.Frequencia,
                                       Grau = a.Grau,
                                       Nota = a.Nota,
                                       Operacional = a.Operacional,
                                       Pubs = a.Pubs
                                   }).ToListAsync());

            return View(await (from a in _context.Avaliacao
                               join b in _context.Usuario on a.UsuarioId equals b.UsuarioId
                               join c in _context.Divisao on a.DivisaoId equals c.DivisaoId
                               where b.UsuarioId == usuario.UsuarioId
                               where a.Exibir == true
                               orderby a.DivisaoId ascending
                               select new AvaliacaoViewModel
                               {
                                   AvaliacaoId = a.AvaliacaoId,
                                   Divisao = c.Nome,
                                   Nome = a.Nome,
                                   DataPP = a.DataPP,
                                   DataMeio = a.DataMeio,
                                   DataFull = a.DataFull,
                                   Acoes = a.Acoes,
                                   Avaliador = b.Nome,
                                   Bondes = a.Bondes,
                                   Contencao = a.Contencao,
                                   Dedicacao = a.Dedicacao,
                                   Estudos = a.Estudos,
                                   Financeiro = a.Financeiro,
                                   Frequencia = a.Frequencia,
                                   Grau = a.Grau,
                                   Nota = a.Nota,
                                   Operacional = a.Operacional,
                                   Pubs = a.Pubs
                               }).ToListAsync());
        }

        public async Task<IActionResult> Details()
        {            
            return View(await (from a in _context.Avaliacao
                               join b in _context.Usuario on a.UsuarioId equals b.UsuarioId
                               join c in _context.Divisao on a.DivisaoId equals c.DivisaoId
                               where a.Exibir == true
                               select new AvaliacaoViewModel
                               {
                                   AvaliacaoId = a.AvaliacaoId,
                                   Divisao = c.Nome,
                                   Nome = a.Nome,
                                   DataPP = a.DataPP,
                                   DataMeio = a.DataMeio,
                                   DataFull = a.DataFull,
                                   Acoes = a.Acoes,
                                   Avaliador = b.Nome,
                                   Bondes = a.Bondes,
                                   Contencao = a.Contencao,
                                   Dedicacao = a.Dedicacao,
                                   Estudos = a.Estudos,
                                   Financeiro = a.Financeiro,
                                   Frequencia = a.Frequencia,
                                   Grau = a.Grau,
                                   Nota = a.Nota,
                                   Operacional = a.Operacional,
                                   Pubs = a.Pubs
                               }).ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["AvaliacaoId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AvaliacaoId,Nome,Grau,DataPP,DataMeio,DataFull,Acoes,Pubs,Bondes,Contencao,Estudos,Financeiro,Operacional,Dedicacao,Frequencia,Nota,Avaliador,DivisaoId,UsuarioId, Observacao")] Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avaliacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AvaliacaoId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", avaliacao.AvaliacaoId);
            return View(avaliacao);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Avaliacao == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.Avaliacao.FindAsync(id);
            if (avaliacao == null)
            {
                return NotFound();
            }
            ViewData["AvaliacaoId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", avaliacao.AvaliacaoId);
            return View(avaliacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AvaliacaoId,Nome,Grau,DataPP,DataMeio,DataFull,Acoes,Pubs,Bondes,Contencao,Estudos,Financeiro,Operacional,Dedicacao,Frequencia,Nota,Avaliador,DivisaoId,UsuarioId,Observacao")] Avaliacao avaliacao)
        {
            if (id != avaliacao.AvaliacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    CalcularNota(avaliacao, _configuration.GetValue<int>("Avaliacao:Questoes"));
                    _context.Update(avaliacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvaliacaoExists(avaliacao.AvaliacaoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
                return RedirectToAction("Index", "Avaliacoes", new { usuarioId = avaliacao.UsuarioId });
            }
            ViewData["AvaliacaoId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", avaliacao.AvaliacaoId);
            return View(avaliacao);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Avaliacao == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.Avaliacao
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AvaliacaoId == id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            return View(avaliacao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Avaliacao == null)
            {
                return Problem("Entity set 'AvaliacaoDbContext.Avaliacao'  is null.");
            }
            var avaliacao = await _context.Avaliacao.FindAsync(id);
            if (avaliacao != null)
            {
                _context.Avaliacao.Remove(avaliacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvaliacaoExists(int id)
        {
            return _context.Avaliacao.Any(e => e.AvaliacaoId == id);
        }

        private static void CalcularNota(Avaliacao avaliacao, int questoes)
        {
            double soma = (
                avaliacao.Acoes
                + avaliacao.Pubs
                + avaliacao.Dedicacao
                + avaliacao.Financeiro
                + avaliacao.Bondes
                + avaliacao.Frequencia
                + avaliacao.Contencao
                + avaliacao.Operacional
                + avaliacao.Estudos);

            avaliacao.Nota = Convert.ToInt32(soma / questoes);
        }
    }
}
