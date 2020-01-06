using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly DatabaseContext context;

        public RoleRepository(DatabaseContext context) : base(context)
        {
            this.context = context;
        }
    }
}
