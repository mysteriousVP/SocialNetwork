using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class UserToLogInDTO
    {
        [Required]
        public string Login { get; set; }
        [Required]
        [StringLength(24, MinimumLength = 8, ErrorMessage = "Password should have lenght from 8 to 24 symbols")]
        public string Password { get; set; }
    }
}
