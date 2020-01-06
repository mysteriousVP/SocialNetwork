using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool IsApproved { get; set; }
        public DateTime PhotoAdded { get; set; }
        public bool IsCurrent { get; set; }
    }
}
