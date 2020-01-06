using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task<IEnumerable<Message>> GetMessages(int userId);
    }
}
