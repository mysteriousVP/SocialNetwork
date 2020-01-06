using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DAL.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirebaseToken { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MaxLength(25)]
        public string Privilege { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        [MaxLength(1500)]
        public string Biography { get; set; }
        [Required]
        public string Gender { get; set; }
        [MaxLength(1500)]
        public string Hobbies { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Message> SentMessages { get; set; }
        public ICollection<Message> ReceivedMesssages { get; set; }
        public ICollection<Friendship> SentFriendshipsQueries { get; set; }
        public ICollection<Friendship> ReceivedFriendshipsQueries { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
