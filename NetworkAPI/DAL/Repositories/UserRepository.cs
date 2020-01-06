using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DatabaseContext context;

        public UserRepository(DatabaseContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<User> GetCurrentUser(string user)
        {
            return await context.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.UserName.ToLower() == user.ToLower());
        }

        public async Task<User> GetUser(int id, bool isCurrentUser = false)
        {
            IQueryable<User> query = context.Users.Include(p => p.Photos)
                .Include(friend => friend.SentFriendshipsQueries)
                .Include(friend => friend.ReceivedFriendshipsQueries).AsQueryable();

            User user;

            if (!isCurrentUser)
            {
                user = await query.FirstOrDefaultAsync(u => u.Id == id);
            }
            else
            {
                user = await query.IgnoreQueryFilters().FirstOrDefaultAsync(u => u.Id == id);
            }

            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users.Include(p => p.Photos).Include(r => r.UserRoles)
                .Include(f => f.SentFriendshipsQueries)
                .Include(f => f.ReceivedFriendshipsQueries);
        }

        public async Task<bool> UserExist(string user)
        {
            bool exist = await context.Users.FirstOrDefaultAsync(x => x.UserName == user) == null ? false : true;

            return exist;
        }
    }
}
