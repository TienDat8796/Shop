using Microsoft.AspNetCore.Mvc;

namespace Nhom_Co_Di_Hoc.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            var username = HttpContext.Session.GetString("Username");
            ViewBag.Username = username;
            return View();
        }
    }

}
