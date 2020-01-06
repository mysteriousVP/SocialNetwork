using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private readonly DatabaseContext context;

        public PostRepository(DatabaseContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Post> GetPost(int postId)
        {
            return await context.Posts.Include(u => u.User)
                                      .Include(l => l.Likes)
                                      .Include(c => c.Comments)
                                      .FirstOrDefaultAsync(p => p.Id == postId);
        }

        public IEnumerable<Post> GetPosts(int userId)
        {
            return context.Posts.Where(p => p.UserId == userId)
                                      .Include(u => u.User)
                                      .Include(l => l.Likes)
                                      .Include(c => c.Comments)
                                      .OrderByDescending(p => p.DateOfCreation);
        }
    }
}
