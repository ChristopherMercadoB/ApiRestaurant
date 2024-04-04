using ApiRestaurant.Core.Application.Enums;
using ApiRestaurant.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;


namespace ApiRestaurant.Infrastructure.Identity.Seeds
{
    public static class DefaultBasicUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser defaultUser = new()
            {
                FirstName = "basic",
                LastName = "b",
                UserName = "basicUser",
                Email = "basicuser@email.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };


            if (userManager.Users.All(u=>u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Pa$$word123!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Waiter.ToString());
                }
            }
        }
    }
}
