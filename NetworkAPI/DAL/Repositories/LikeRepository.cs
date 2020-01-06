using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DAL.DataContext;

namespace DAL.Repositories
{
    public class LikeRepository : Repository<Like>, ILikeRepository
    {
        private readonly DatabaseContext context;

        public LikeRepository(DatabaseContext context) : base(context)
        {
            this.context = context; 
        }
    }
}
