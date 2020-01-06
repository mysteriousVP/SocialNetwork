using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class UserToUpdateDTO
    {
        public string FairbaseToken { get; set; }
        public string Biography { get; set; }
        public string Hobbies { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
