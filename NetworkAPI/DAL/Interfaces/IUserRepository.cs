using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetCurrentUser(string user);
        IEnumerable<User> GetUsers();
        Task<User> GetUser(int id, bool isCurrentUser = false);
        Task<bool> UserExist(string user);
    }
}
