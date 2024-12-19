using System.ComponentModel.DataAnnotations.Schema;

namespace Nhom_Co_Di_Hoc.Model
{
    [Table("NguoiDung")]
    public class NguoiDung
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

}
