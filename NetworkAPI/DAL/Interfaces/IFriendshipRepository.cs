using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IFriendshipRepository : IRepository<Friendship>
    {
        Task<Friendship> GetFriendship(int senderId, int recipientId);
        Task<IEnumerable<Friendship>> GetSentFriendships(int id);
        Task<IEnumerable<Friendship>> GetRequestFriendships(int id);
    }
}
