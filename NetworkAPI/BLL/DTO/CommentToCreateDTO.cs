using System;

namespace BLL.DTO
{
    public class CommentToCreateDTO
    {
        public string Content { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime DateOfCreation { get; set; }

        public CommentToCreateDTO()
        {
            DateOfCreation = DateTime.Now;
        }
    }
}
