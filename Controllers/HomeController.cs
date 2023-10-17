using Avaliacoes.Models;
using Avaliacoes.Domain;
using Avaliacoes.Context;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

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
                var usuario = _context.Usuario.Where(u => u.Email == email);

                if (usuario.Any())
                {
                    var claims = new List<Claim>
                    { 
                        new Claim(ClaimTypes.Name, email)
                    };

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                        new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)));

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