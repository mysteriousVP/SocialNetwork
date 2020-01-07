using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFriendshipService
    {
        Task<bool> AddFriend(int senderId, int recipientId);
        Task<IEnumerable<UserToListDTO>> GetAllFriends(int userId);
        Task<IEnumerable<UserToListDTO>> GetAllSubscribers(int userId);
        Task<IEnumerable<UserToListDTO>> GetAllFollowings(int userId);
        Task<bool> DeleteFriend(int sender, int recipientId);
        Task<bool> CheckOnFriendship(int senderId, int recipientId);
    }
}
