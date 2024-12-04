using System.ComponentModel.DataAnnotations;

namespace UserModel.Models
{
    public class User
    {
        public int Id { get; set; }
        [MinLength(5), MaxLength(254)]
        public string Email { get; set; } = null!;
        [MinLength(8), MaxLength(50)]
        public string Password { get; set; } = null!;
    }
}
