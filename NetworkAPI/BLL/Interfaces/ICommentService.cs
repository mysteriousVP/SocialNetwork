using BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICommentService
    {
        Task<CommentDTO> CreateComment(CommentToCreateDTO comment);
        Task<bool> DeleteComment(int commentId, int userId);
        Task<IEnumerable<CommentDTO>> GetComments(int postId);
        Task<CommentDTO> GetCommentById(int id);
    }
}
