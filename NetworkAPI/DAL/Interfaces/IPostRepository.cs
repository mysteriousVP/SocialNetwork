using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<Post> GetPost(int postId);
        IEnumerable<Post> GetPosts(int userId);
    }
}
