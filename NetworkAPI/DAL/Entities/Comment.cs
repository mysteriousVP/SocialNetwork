using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        [MaxLength(1000)]
        [Required]
        public string Content { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
