using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DAL.Repositories
{
    public class FriendshipRepository : Repository<Friendship>, IFriendshipRepository
    {
        private readonly DatabaseContext context;

        public FriendshipRepository(DatabaseContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Friendship> GetFriendship(int senderId, int recipientId)
        {
            return context.Friendships.FirstOrDefault(f => f.SenderId == senderId && f.RecipientId == recipientId);
        }

        public async Task<IEnumerable<Friendship>> GetRequestFriendShips(int id)
        {
            return context.Friendships.Where(f => f.RecipientId == id);
        }

        public async Task<IEnumerable<Friendship>> GetSentFriendships(int id)
        {
            return context.Friendships.Where(f => f.SenderId == id);
        }
    }
}
