using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class PhotoToCreateDTO
    {
        public string URL { get; set; }
        public string Description { get; set; }
        public DateTime PhotoAdded { get; set; }
        public IFormFile File { get; set; }

        public PhotoToCreateDTO()
        {
            PhotoAdded = DateTime.Now;
        }
    }
}
