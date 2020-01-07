using AutoMapper;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL.Configuration;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<PostDTO> CreatePost(PostToCreateDTO post)
        {
            Post newPost = mapper.Map<Post>(post);

            if (newPost.Content.Length > LenghtRestrictions.POST_MAX_LENGTH)
            {
                newPost.Content = newPost.Content.Substring(0, LenghtRestrictions.POST_MAX_LENGTH);
            }

            unitOfWork.PostRepository.Add(newPost);

            if (await unitOfWork.SaveChanges())
            {
                return mapper.Map<PostDTO>(post);
            }

            throw new ServicesException("Saving your post is failed.");
        }

        public async Task<bool> DeletePost(int id)
        {
            Post postToDelete = await unitOfWork.PostRepository.GetPost(id);
            unitOfWork.PostRepository.Remove(postToDelete);

            return await unitOfWork.SaveChanges();
        }

        public async Task<IEnumerable<PostDTO>> GetPosts(int userId)
        {
            IEnumerable<Post> posts = unitOfWork.PostRepository.GetPosts(userId);

            foreach (Post post in posts)
            {
                post.Comments.OrderBy(x => x.DateOfCreation);
            }

            return mapper.Map<IEnumerable<PostDTO>>(posts);
        }

        public async Task<PostDTO> GetPostById(int id)
        {
            Post post = await unitOfWork.PostRepository.GetPost(id);

            return mapper.Map<PostDTO>(post);
        }
    }
}
