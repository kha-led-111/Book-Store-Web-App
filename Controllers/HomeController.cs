using System.Diagnostics;
using Bookstore_Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore_Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index","Book");
        }

      

        
    }
}
