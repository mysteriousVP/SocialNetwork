using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPhotoRepository : IRepository<Photo>
    {
        Task<IEnumerable<Photo>> GetUnapprovedPhotos();
        Task<Photo> GetUnapprovedPhoto(int photoId);
        Task<Photo> GetCurrentUserPhoto(int userId);
        Task<Photo> AddPhotoForUser(User user, Photo photo);
    }
}
