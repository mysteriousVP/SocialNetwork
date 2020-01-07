using AutoMapper;
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
    public class LikeService : ILikeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public LikeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> DeleteLike(int postId, int userId)
        {
            Like like = (await unitOfWork.LikeRepository.GetAll())
                .Where(p => p.PostId == postId && p.UserId == userId).FirstOrDefault();

            if (like == null)
            {
                throw new ServicesException("Like does not exist.");
            }

            unitOfWork.LikeRepository.Remove(like);

            return await unitOfWork.SaveChanges();
        }

        public async Task<bool> PutLike(int postId, int userId)
        {
            IEnumerable<Like> likes = await unitOfWork.LikeRepository.GetAll();

            if (likes.Any(p => p.PostId == postId && p.UserId == userId))
            {
                throw new ServicesException("Like is already putted.");
            }

            Like like = new Like()
            {
                PostId = postId,
                UserId = userId
            };

            unitOfWork.LikeRepository.Add(like);

            return await unitOfWork.SaveChanges();
        }
    }
}
