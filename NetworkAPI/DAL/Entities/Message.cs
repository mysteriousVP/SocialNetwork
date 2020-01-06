using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Message
    {
        public int Id { get; set; }
        [MaxLength(700)]
        [Required]
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public DateTime MessageSent { get; set; }
        public bool SenderDeleted { get; set; }
        public bool RecipientDeleted { get; set; }
        public int SenderId { get; set; }
        public User Sender { get; set; }
        public int RecipientId { get; set; }
        public User Recipient { get; set; }
    }
}