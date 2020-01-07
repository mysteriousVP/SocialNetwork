using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPostService
    {
        Task<PostDTO> GetPostById(int id);
        Task<IEnumerable<PostDTO>> GetPosts(int userId);
        Task<PostDTO> CreatePost(PostToCreateDTO post);
        Task<bool> DeletePost(int id);
    }
}
