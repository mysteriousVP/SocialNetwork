using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace BLL.Configuration
{
    public class IdentityDataInitializer
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;

        public IdentityDataInitializer(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void SeedRoles()
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                Role role = new Role();
                role.Name = "CasualUser";
                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("Moderator").Result)
            {
                Role role = new Role();
                role.Name = "SiteModerator";
                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("Administator").Result)
            {
                Role role = new Role();
                role.Name = "Administator";
                roleManager.CreateAsync(role).Wait();
            }
        }

        public void SeedAdministrator()
        {
            if (userManager.Users.FirstOrDefault(u => u.UserName == "Administator") == null)
            {
                User administrator = new User()
                {
                    UserName = "Administator",
                    Gender = "Male",
                    Privilege = "Administator"
                };

                IdentityResult identityResult = userManager.CreateAsync(administrator, "admin").Result;

                if (identityResult.Succeeded)
                {
                    User user = userManager.FindByNameAsync("Administator").Result;

                    userManager.AddToRolesAsync(user, new[] { "Moderator", "User", "Administrator" }).Wait();
                }
            }
        }

        public void SeedModerator()
        {
            if (userManager.Users.FirstOrDefault(u => u.UserName == "Moderator") == null)
            {
                User moderator = new User()
                {
                    UserName = "Moderator",
                    Gender = "Female",
                    Privilege = "Moderator"
                };

                IdentityResult identityResult = userManager.CreateAsync(moderator, "moderator").Result;

                if (identityResult.Succeeded)
                {
                    User user = userManager.FindByNameAsync("Moderator").Result;

                    userManager.AddToRolesAsync(user, new[] { "Moderator", "User" }).Wait();
                }
            }
        }
    }
}
