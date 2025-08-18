using JMVPageLogic.Core.Application.Enum;
using JMVPageLogic.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace JMVPageLogic.Infrastructure.Identity.Seeds
{
    public class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(RolesEnum.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(RolesEnum.Admin.ToString()));
        }
    }
}
