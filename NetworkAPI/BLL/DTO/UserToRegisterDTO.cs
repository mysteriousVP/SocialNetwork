using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class UserToRegisterDTO
    {
        [Required]
        public string Login { get; set; }
        [Required]
        [StringLength(24, MinimumLength = 8, ErrorMessage = "Password should have lenght from 8 to 24 symbols")]
        public string Password { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [MaxLength(25)]
        public string Privilege { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [MaxLength(1500)]
        public string Biography { get; set; }
        [MaxLength(1500)]
        public string Hobbies { get; set; }

        public UserToRegisterDTO()
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
        }
    }
}
