using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Speedfit.Domain.Entities;
using SpeedFit.Domain.Entities;
using SpeedFit.Models;

namespace SpeedFit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index(string id)
        {
            if (id == null)
            {
                return Redirect("https://localhost:44328/Identity/Account/Login");
            }
            ProjetoContext _context = new ProjetoContext();
            Usuario usuario = _context.Usuario.Where(x => x.Email == id).FirstOrDefault();

            switch (usuario.TipoUsuario)
            {
                case Speedfit.Models.Enums.TipoUsuario.Usuario:
                    return View(usuario);
                case Speedfit.Models.Enums.TipoUsuario.Nutricionista:
                    return RedirectToAction("Index", "Dieta");
                case Speedfit.Models.Enums.TipoUsuario.EducadorFisico:
                    return RedirectToAction("Index", "Treino");
                default:
                    return Redirect("https://localhost:44328/Identity/Account/Login");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
