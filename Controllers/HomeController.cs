using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTe.Models;
using MyTE.Data;
using MyTE.Models;
using System.Diagnostics;

namespace MyTe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            Login login = new Login();
            return View(login);
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

        [HttpPost]
        public IActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                // Consulte o banco de dados para verificar se as credenciais são válidas
                var user = _dbContext.Usuarios.FirstOrDefault(u => u.Email == model.Email && u.Senha == model.Password);

                if (user != null)
                {
                    // Credenciais válidas, redireciona para a página de horas
                    return RedirectToAction("Index", "Horas");
                }
                else
                {
                    ModelState.AddModelError("", "Credenciais inválidas. Por favor, tente novamente.");
                    return View("Index", model);
                }
            }

            return View("Index", model);
        }

    }
}
