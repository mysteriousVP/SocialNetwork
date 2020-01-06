using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Post
    {
        public int Id { get; set; }
        [MaxLength(2000)]
        [Required]
        public string Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}
