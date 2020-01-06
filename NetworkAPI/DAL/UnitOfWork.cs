using DAL.DataContext;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DatabaseContext context;

        private IUserRepository userRepository;
        private IPostRepository postRepository;
        private ICommentRepository commentRepository;
        private ILikeRepository likeRepository;
        private IFriendshipRepository friendshipRepository;
        private IMessageRepository messageRepository;
        private IPhotoRepository photoRepository;
        private IRoleRepository roleRepository;

        public UnitOfWork(DatabaseContext context)
        {
            this.context = context;
        }

        public IUserRepository UserRepository
        {
            get
            {
                return userRepository ??= userRepository ?? new UserRepository(context);
            }
        }

        public IPostRepository PostRepository
        {
            get
            {
                return postRepository ??= postRepository ?? new PostRepository(context);
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                return commentRepository ??= new CommentRepository(context);
            }
        }

        public ILikeRepository LikeRepository
        {
            get
            {
                return likeRepository ??= new LikeRepository(context);
            }
        }

        public IFriendshipRepository FriendshipRepository
        {
            get
            {
                return friendshipRepository ??= new FriendshipRepository(context);
            }
        }

        public IMessageRepository MessageRepository
        {
            get
            {
                return messageRepository ??= new MessageRepository(context);
            }
        }

        public IPhotoRepository PhotoRepository
        {
            get
            {
                return photoRepository ??= new PhotoRepository(context);
            }
        }


        public IRoleRepository RoleRepository
        {
            get
            {
                return roleRepository ??= new RoleRepository(context);
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<bool> SaveChanges()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
