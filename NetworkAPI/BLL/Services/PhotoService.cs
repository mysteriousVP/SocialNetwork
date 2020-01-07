using AutoMapper;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PhotoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<PhotoDTO> CreatePhotoToUser(int userId, PhotoToCreateDTO photo)
        {
            Photo newPhoto = mapper.Map<Photo>(photo);

            User userById = await unitOfWork.UserRepository.GetUser(userId, true);

            if (userById != null)
            {
                await unitOfWork.PhotoRepository.AddPhotoForUser(userById, newPhoto);

                if (await unitOfWork.SaveChanges())
                {
                    return mapper.Map<PhotoDTO>(newPhoto);
                }
            }

            throw new ServicesException("Saving your photo is failed.");
        }

        public async Task<bool> DeletePhoto(int userId, int photoId)
        {
            User currentUser = await unitOfWork.UserRepository.GetUser(userId, true);

            if (currentUser.Photos.Any(p => p.Id == photoId) == false)
            {
                throw new ServicesException("This user does not have this photo.");
            }

            Photo photo = await unitOfWork.PhotoRepository.Get(photoId);

            if (photo.IsCurrent == true)
            {
                throw new ServicesException("This photo is already current for this user. " +
                    "Choose another photo to change avatar.");
            }

            unitOfWork.PhotoRepository.Remove(photo);

            return await unitOfWork.SaveChanges();
        }

        public async Task<PhotoDTO> GetPhoto(int id)
        {
            Photo photo = await unitOfWork.PhotoRepository.Get(id);

            return mapper.Map<PhotoDTO>(photo);
        }

        public async Task<bool> SetCurrentPhoto(int userId, int photoId)
        {
            User currentUser = await unitOfWork.UserRepository.GetUser(userId, true);

            if (currentUser.Photos.Any(p => p.Id == photoId) == false)
            {
                throw new ServicesException("This user does not have this photo.");
            }

            Photo photo = await unitOfWork.PhotoRepository.Get(photoId);

            if (photo.IsCurrent == false)
            {
                Photo currentPhoto = await unitOfWork.PhotoRepository.GetCurrentUserPhoto(userId);
                currentPhoto.IsCurrent = false;
                photo.IsCurrent = true;

                return await unitOfWork.SaveChanges();
            }

            throw new ServicesException("This photo is already current for this user. " +
                "Choose another photo to change avatar.");
        }
    }
}
