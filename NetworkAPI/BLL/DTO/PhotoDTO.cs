using System;

namespace BLL.DTO
{
    public class PhotoDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public bool IsApproved { get; set; }
        public DateTime PhotoAdded { get; set; }
        public bool IsCurrent { get; set; }
    }
}
