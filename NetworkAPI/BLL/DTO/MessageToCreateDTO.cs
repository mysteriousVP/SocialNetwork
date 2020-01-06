using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class MessageToCreateDTO
    {
        public string Content { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public DateTime MessageSent { get; set; }

        public MessageToCreateDTO()
        {
            MessageSent = DateTime.Now;
        }
    }
}
