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
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly DatabaseContext context;

        public CommentRepository(DatabaseContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Comment> GetComment(int id)
        {
            return await context.Comments.Include(u => u.User).ThenInclude(p => p.Photos).FirstOrDefaultAsync();
        }
    }
}
