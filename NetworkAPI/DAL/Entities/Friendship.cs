namespace DAL.Entities
{
    public class Friendship
    {
        public int SenderId { get; set; }
        public User Sender { get; set; }
        public int RecipientId { get; set; }
        public User Recipient { get; set; }
    }
}