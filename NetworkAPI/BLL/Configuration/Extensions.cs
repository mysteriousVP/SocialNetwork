using DAL;
using DAL.DataContext;
using DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using DAL.Entities;

namespace BLL.Configuration
{
    public static class Extensions
    {
        public static int CalculateUserAge(this DateTime birthdayTime)
        {
            int age = DateTime.Now.Year - birthdayTime.Year;

            if (birthdayTime.AddYears(age) > DateTime.Today)
            {
                age--;
            }

            return age;
        }

        public static IServiceCollection SetScopes(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            // add services
            return services;
        }

        public static IServiceCollection SetConnectionStringToContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DatabaseContext>(x => x.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection SetIdentityRoles(this IServiceCollection services)
        {
            IdentityBuilder identityBuilder = services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequiredLength = 8;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireNonAlphanumeric = false;
            });

            identityBuilder = new IdentityBuilder(identityBuilder.UserType, typeof(Role), identityBuilder.Services);
            identityBuilder.AddEntityFrameworkStores<DatabaseContext>();
            identityBuilder.AddRoleManager<RoleManager<Role>>();
            identityBuilder.AddRoleValidator<RoleValidator<Role>>();
            identityBuilder.AddSignInManager<SignInManager<User>>();

            return services;
        }
    }
}
