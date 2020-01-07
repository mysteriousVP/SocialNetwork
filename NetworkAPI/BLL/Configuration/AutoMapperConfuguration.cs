using System.Linq;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Configuration
{
    public class AutoMapperConfuguration : Profile
    {
        public AutoMapperConfuguration()
        {
            CreateMap<CommentToCreateDTO, Comment>();
            CreateMap<Comment, CommentDTO>()
                .ForMember(com => com.PhotoUrl,
                    opt => opt.MapFrom(u => u.User.Photos.FirstOrDefault(p => p.IsCurrent).URL));

            CreateMap<Like, LikerDTO>()
                .ForMember(m => m.UserName, opt =>
                    opt.MapFrom(u => u.User.Privilege))
                .ForMember(m => m.PhotoUrl, opt =>
                    opt.MapFrom(u => u.User.Photos.FirstOrDefault(p => p.IsCurrent).URL))
                .ForMember(m => m.Id, opt =>
                    opt.MapFrom(u => u.UserId));

            CreateMap<Photo, PhotoDTO>();
            CreateMap<PhotoToCreateDTO, Photo>();

            CreateMap<Message, MessageDTO>()
                .ForMember(m => m.SenderPhotoURL, opt =>
                    opt.MapFrom(u => u.Sender.Photos.FirstOrDefault(p => p.IsCurrent).URL))
                .ForMember(m => m.RecipientPhotoURL, opt =>
                    opt.MapFrom(u => u.Recipient.Photos.FirstOrDefault(p => p.IsCurrent).URL));
            CreateMap<MessageToCreateDTO, Message>();

            CreateMap<PostToCreateDTO, Post>();
            CreateMap<Post, PostDTO>()
                .ForMember(m => m.Username, opt =>
                    opt.MapFrom(u => u.User.UserName))
                .ForMember(m => m.PhotoUrl, opt =>
                    opt.MapFrom(u => u.User.Photos.FirstOrDefault(p => p.IsCurrent).URL))
                .ForMember(m => m.Likers, opt =>
                    opt.MapFrom(l => l.Likes))
                 .ForMember(m => m.Comments, opt =>
                    opt.MapFrom(l => l.Comments));

            CreateMap<UserToUpdateDTO, User>();
            CreateMap<User, UserToRegisterDTO>().ReverseMap();
            CreateMap<User, UserToListDTO>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsCurrent).URL);
                })
                .ForMember(dest => dest.Age, opt =>
                {
                    opt.MapFrom(d => d.DateOfBirth.CalculateUserAge());
                }).ReverseMap();
            CreateMap<User, UserToDetaliedLookDTO>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.Where(p => p.IsApproved == true)
                    .FirstOrDefault(p => p.IsCurrent).URL);
                })
                .ForMember(dest => dest.Age, opt =>
                {
                    opt.MapFrom(d => d.DateOfBirth.CalculateUserAge());
                });
        }
    }
}
