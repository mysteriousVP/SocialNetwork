using AutoMapper;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class FriendshipService : IFriendshipService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public FriendshipService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> AddFriend(int senderId, int recipientId)
        {
            Friendship friendship = new Friendship()
            {
                SenderId = senderId,
                RecipientId = recipientId
            };

            unitOfWork.FriendshipRepository.Add(friendship);

            return await unitOfWork.SaveChanges();
        }

        public async Task<bool> CheckOnFriendship(int senderId, int recipientId)
        {
            Friendship friendship = await unitOfWork.FriendshipRepository.GetFriendship(senderId, recipientId);

            return friendship == null ? false : true;
        }

        public async Task<bool> DeleteFriend(int senderId, int recipientId)
        {
            User user = await unitOfWork.UserRepository.GetUser(senderId);

            if (user.SentFriendshipsQueries.Any(x => x.RecipientId == recipientId))
            {
                throw new ServicesException("This user is not your friend.");
            }

            IEnumerable<Friendship> friendships = await unitOfWork.FriendshipRepository.GetAll();

            Friendship friendship = friendships.Where(p => p.SenderId == senderId && p.RecipientId == recipientId)
                                               .FirstOrDefault();

            unitOfWork.FriendshipRepository.Remove(friendship);

            return await unitOfWork.SaveChanges();
        }

        public async Task<IEnumerable<UserToListDTO>> GetAllFollowings(int userId)
        {
            IEnumerable<Friendship> sentFriendships = await unitOfWork.FriendshipRepository.GetSentFriendships(userId);
            IEnumerable<Friendship> requestedFriendships = await unitOfWork.FriendshipRepository.GetRequestFriendships(userId);

            IEnumerable<int> followingsId = sentFriendships.Where(sent =>
                requestedFriendships.Where(req => req.SenderId == sent.RecipientId && req.RecipientId == sent.SenderId)
                                    .FirstOrDefault() == null).Select(s => s.RecipientId);

            IEnumerable<User> users = unitOfWork.UserRepository.GetUsers();

            users = users.Where(u => followingsId.Contains(u.Id));

            return mapper.Map<IEnumerable<UserToListDTO>>(users);
        }

        public async Task<IEnumerable<UserToListDTO>> GetAllFriends(int userId)
        {
            IEnumerable<Friendship> sentFriendships = await unitOfWork.FriendshipRepository.GetSentFriendships(userId);
            IEnumerable<Friendship> requestedFriendships = await unitOfWork.FriendshipRepository.GetRequestFriendships(userId);

            IEnumerable<int> friendsId = sentFriendships.Where(sent =>
                requestedFriendships.Where(req => req.SenderId == sent.RecipientId && req.RecipientId == sent.SenderId)
                                    .FirstOrDefault() != null).Select(s => s.RecipientId);

            IEnumerable<User> users = unitOfWork.UserRepository.GetUsers();

            users = users.Where(u => friendsId.Contains(u.Id));

            return mapper.Map<IEnumerable<UserToListDTO>>(users);
        }

        public async Task<IEnumerable<UserToListDTO>> GetAllSubscribers(int userId)
        {
            IEnumerable<Friendship> sentFriendships = await unitOfWork.FriendshipRepository.GetSentFriendships(userId);
            IEnumerable<Friendship> requestedFriendships = await unitOfWork.FriendshipRepository.GetRequestFriendships(userId);

            IEnumerable<int> subscribersId = requestedFriendships.Where(sent =>
               sentFriendships.Where(req => req.SenderId == sent.RecipientId && req.RecipientId == sent.SenderId)
                              .FirstOrDefault() == null).Select(s => s.SenderId);

            IEnumerable<User> users = unitOfWork.UserRepository.GetUsers();

            users = users.Where(u => subscribersId.Contains(u.Id));

            return mapper.Map<IEnumerable<UserToListDTO>>(users);
        }
    }
}
