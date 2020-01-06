using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Username { get; set; }
        public string PhotoUrl { get; set; }
    }
}
