using Microsoft.AspNetCore.Mvc;
using suppliers.Models;
using System.Linq;

namespace suppliers.Controllers
{
    public class HomeController : Controller
    {
        private DataContext context;

        public HomeController(DataContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Message = "Мониторинг цен";
            return View(context.Products.OrderBy(p => p.ProductId).First());
        }
    }
}
