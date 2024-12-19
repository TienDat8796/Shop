using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nhom_Co_Di_Hoc.Data;
using Nhom_Co_Di_Hoc.Model;
using Nhom_Co_Di_Hoc.Model.Dto;

namespace Nhom_Co_Di_Hoc.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DonHangController : Controller
    {
        private readonly ShopPhuKienContext _context;

        public DonHangController(ShopPhuKienContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var donHangs = _context.DonHangs.Include(d => d.NguoiDung).ToList();
            return View(donHangs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                _context.DonHangs.Add(donHang);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(donHang);
        }

        public IActionResult Details(int id)
        {
            var donHang = _context.DonHangs.Include(d => d.NguoiDung)
                                            .Include(d => d.ChiTietDonHangs)
                                            .FirstOrDefault(d => d.Id == id);
            if (donHang == null)
            {
                return NotFound();
            }
            return View(donHang);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDonHang([FromBody] DonHangDto donHang)
        {
            if (donHang == null || donHang.ChiTietDonHangs == null || !donHang.ChiTietDonHangs.Any())
            {
                return BadRequest(new { success = false, message = "Dữ liệu không hợp lệ." });
            }

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    donHang.NgayDatHang = DateTime.Now;
                    var donHangDB = new DonHang()
                    {
                        NguoiDungID = donHang.NguoiDungID,
                        Ten = donHang.Ten,
                        Tuoi = donHang.Tuoi,
                        DiaChi = donHang.DiaChi,
                        SoDienThoai = donHang.SoDienThoai,
                        TongThanhTien = donHang.TongThanhTien
                    };
                    _context.DonHangs.Add(donHangDB);
                    await _context.SaveChangesAsync();

                    foreach (var chiTiet in donHang.ChiTietDonHangs)
                    {
                        var donHangChiTiet = new ChiTietDonHang()
                        {
                            MaSanPham = chiTiet.MaSanPham,
                            SoLuong = chiTiet.SoLuong,
                            TenSanPham = chiTiet.TenSanPham,
                            DonHangId = donHangDB.Id,
                            Gia = chiTiet.Gia,
                        };
                        _context.ChiTietDonHangs.Add(donHangChiTiet);
                    }
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return Ok(new { success = true });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return StatusCode(500, new { success = false, message = ex.Message });
                }
            }
        }


    }
}
