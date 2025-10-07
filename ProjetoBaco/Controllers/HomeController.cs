using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoBaco.Controllers
{
    public class HomeController(IRepositoryBase repo) : Controller
    {
        private readonly IRepositoryBase _repo = repo;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IniciarBanco()
        {
            _repo.Init();
            return View();
        }
    }
}
