namespace Nhom_Co_Di_Hoc.Model.Dto
{
    public class DonHangDto
    {
        public int Id { get; set; }
        public int NguoiDungID { get; set; }
        public string Ten { get; set; }
        public int Tuoi { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public decimal TongThanhTien { get; set; }
        public DateTime NgayDatHang { get; set; }

        public List<ChiTietDonHangDto> ChiTietDonHangs { get; set; }
    }

}
