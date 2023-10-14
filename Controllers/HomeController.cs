using Avaliacoes.Models;
using Avaliacoes.Context;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Avaliacoes.Domain;

namespace Avaliacoes.Controllers
{
    public class HomeController : Controller
    {
        private readonly AvaliacaoDbContext _context;

        public HomeController(AvaliacaoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Validar(string email)
        {
            try
            {
                var validaUsuario = _context.Usuario.Where(u => u.Email == email);

                if (validaUsuario.Any())
                {
                    var usuario = validaUsuario.FirstOrDefault();
                    Acesso.usuario = usuario.UsuarioId;
                    return RedirectToAction("Index", "Avaliacoes");
                }             
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
            return RedirectToAction("Error");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}