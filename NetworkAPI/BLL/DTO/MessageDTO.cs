using System;

namespace BLL.DTO
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public DateTime MessageSent { get; set; }
        public bool SenderDeleted { get; set; }
        public bool RecipientDeleted { get; set; }
        public int SenderId { get; set; }
        public string SenderPhotoURL { get; set; }
        public string SenderName { get; set; }
        public int RecipientId { get; set; }
        public string RecipientPhotoURL { get; set; }
        public string RecipientName { get; set; }
    }
}
