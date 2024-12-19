using Microsoft.AspNetCore.Mvc;
using Nhom_Co_Di_Hoc.Data;

namespace Nhom_Co_Di_Hoc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopPhuKienContext _context;

        public HomeController(ShopPhuKienContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.SanPhams.ToList(); 
            return View(products); 
        }
    }
}
