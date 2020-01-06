using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        private readonly DatabaseContext context;

        public MessageRepository(DatabaseContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Message>> GetMessages(int userId)
        {
            return context.Messages.Include(m => m.Sender).ThenInclude(p => p.Photos)
                                   .Include(m => m.Recipient).ThenInclude(p => p.Photos)
                                   .Where(m => m.SenderId == userId || m.RecipientId == userId);
        }
    }
}
