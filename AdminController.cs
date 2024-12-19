using Microsoft.AspNetCore.Mvc;
using Nhom_Co_Di_Hoc.Data;
using Nhom_Co_Di_Hoc.Model;
using System.Linq;

namespace Nhom_Co_Di_Hoc.Controllers
{
    public class AdminController : Controller
    {
        private readonly ShopPhuKienContext _context;

        public AdminController(ShopPhuKienContext context)
        {
            _context = context;
        }
        private IActionResult CheckLogin()
        {
            if (HttpContext.Session.GetString("AdminUsername") == null)
            {
                return RedirectToAction("Login");
            }
            return null;
        }

        public IActionResult Index()
        {
            var checkLogin = CheckLogin();
            if (checkLogin != null) return checkLogin;

            var sanPhams = _context.SanPhams.ToList();
            return View(sanPhams);
        }

        public IActionResult Delete(int id)
        {
            var checkLogin = CheckLogin();
            if (checkLogin != null) return checkLogin;

            var sanPham = _context.SanPhams.Find(id);
            if (sanPham == null) return NotFound();
            return View(sanPham);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var sanPham = _context.SanPhams.Find(id);
            if (sanPham != null)
            {
                _context.SanPhams.Remove(sanPham);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
