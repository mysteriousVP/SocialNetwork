using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class UserRoles
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public List<string> Roles { get; set; }
    }
}
