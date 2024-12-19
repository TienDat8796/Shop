using System.ComponentModel.DataAnnotations;

namespace Nhom_Co_Di_Hoc.Model
{
    public class SanPham
    {
        public int MaSanPham { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống.")]
        public string TenSanPham { get; set; }

        [Required(ErrorMessage = "Mô tả sản phẩm không được để trống.")]
        public string MoTa { get; set; }

        [Required(ErrorMessage = "Giá không được để trống.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0.")]
        public decimal Gia { get; set; }

        public string? Anh { get; set; }
    }
}
