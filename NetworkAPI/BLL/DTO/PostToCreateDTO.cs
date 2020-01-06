using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class PostToCreateDTO
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public DateTime DateOfCreation { get; set; }

        public PostToCreateDTO()
        {
            DateOfCreation = DateTime.Now;
        }
    }
}
