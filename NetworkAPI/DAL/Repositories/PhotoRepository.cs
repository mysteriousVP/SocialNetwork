using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        private readonly DatabaseContext context;

        public PhotoRepository(DatabaseContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Photo> AddPhotoForUser(User user, Photo photo)
        {
            if (!user.Photos.Any(u => u.IsCurrent))
            {
                photo.IsCurrent = true;
            }

            user.Photos.Add(photo);

            return photo;
        }

        public async Task<Photo> GetCurrentUserPhoto(int userId)
        {
            return await context.Photos.Where(u => u.UserId == userId).FirstOrDefaultAsync(p => p.IsCurrent == true);
        }

        public async Task<Photo> GetUnapprovedPhoto(int photoId)
        {
            Photo photo = await context.Photos.IgnoreQueryFilters().FirstOrDefaultAsync(p => p.Id == photoId);

            return photo;
        }

        public async Task<IEnumerable<Photo>> GetUnapprovedPhotos()
        {
            IQueryable<Photo> query = context.Photos.AsQueryable().IgnoreQueryFilters();
            IEnumerable<Photo> photos = query.Where(p => p.IsApproved == false);

            return photos;
        }
    }
}
