using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<Comment> GetComment(int id);
    }
}
