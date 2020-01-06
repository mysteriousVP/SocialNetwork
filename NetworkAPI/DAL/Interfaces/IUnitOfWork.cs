using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IPostRepository PostRepository { get; }
        ICommentRepository CommentRepository { get; }
        ILikeRepository LikeRepository { get; }
        IFriendshipRepository FriendshipRepository { get; }
        IMessageRepository MessageRepository { get; }
        IPhotoRepository PhotoRepository { get; }
        IRoleRepository RoleRepository { get; }

        Task<bool> SaveChanges();
    }
}
