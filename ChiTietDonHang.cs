namespace Nhom_Co_Di_Hoc.Model
{
    public class ChiTietDonHang
    {
        public int Id { get; set; }
        public int DonHangId { get; set; }
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
    }

}
