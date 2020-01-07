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
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CommentDTO> CreateComment(CommentToCreateDTO comment)
        {
            Comment newComment = mapper.Map<Comment>(comment);
            
            if (newComment.Content.Length > LenghtRestrictions.COMMENT_MAX_LENGTH)
            {
                newComment.Content = newComment.Content.Substring(0, LenghtRestrictions.COMMENT_MAX_LENGTH);
            }

            unitOfWork.CommentRepository.Add(newComment);

            if (await unitOfWork.SaveChanges())
            {
                return mapper.Map<CommentDTO>(newComment);
            }

            throw new ServicesException("Saving your comment is failed. Try again.");
        }

        public async Task<bool> DeleteComment(int commentId, int userId)
        {
            IEnumerable<Comment> comments = await unitOfWork.CommentRepository.GetAll();
            Comment comment = comments.Where(p => p.UserId == userId && p.Id == commentId).FirstOrDefault();

            if (comment != null)
            {
                unitOfWork.CommentRepository.Remove(comment);

                return await unitOfWork.SaveChanges();
            }

            throw new ServicesException("This comment does not exist. Try again.");
        }

        public async Task<CommentDTO> GetCommentById(int id)
        {
            Comment comment = await unitOfWork.CommentRepository.GetComment(id);

            if (comment != null)
            {
                return mapper.Map<CommentDTO>(comment);
            }

            throw new ServicesException("Comment does not exist.");
        }

        public async Task<IEnumerable<CommentDTO>> GetComments(int postId)
        {
            IEnumerable<Comment> comments = await unitOfWork.CommentRepository.GetAll();

            comments.OrderBy(x => x.DateOfCreation);

            return mapper.Map<IEnumerable<CommentDTO>>(comments);
        }
    }
}
