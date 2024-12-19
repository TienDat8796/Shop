using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Nhom_Co_Di_Hoc.Data;
using Nhom_Co_Di_Hoc.Model;

namespace Nhom_Co_Di_Hoc.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly ShopPhuKienContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SanPhamController(ShopPhuKienContext context)
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
            var sanPhams = _context.SanPhams.ToList();
            return View(sanPhams);
        }

        public IActionResult Details(int id)
        {
            var sanPham = _context.SanPhams.Find(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            return View(sanPham);
        }

        public IActionResult Edit(int id)
        {
            var sanPham = _context.SanPhams.Find(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            return View(sanPham);
        }

        [HttpPost]
        public IActionResult Edit(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                _context.SanPhams.Update(sanPham);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(sanPham);
        }

        public IActionResult Delete(int id)
        {
            var sanPham = _context.SanPhams.Find(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            return View(sanPham);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var sanPham = _context.SanPhams.Find(id);
            _context.SanPhams.Remove(sanPham);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
