using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using suppliers.Models;

namespace suppliers.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
