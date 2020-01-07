using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPhotoService
    {
        Task<PhotoDTO> GetPhoto(int id);
        Task<bool> DeletePhoto(int userId, int photoId);
        Task<bool> SetCurrentPhoto(int userId, int photoId);
        Task<PhotoDTO> CreatePhotoToUser(int userId, PhotoToCreateDTO photo);
    }
}
