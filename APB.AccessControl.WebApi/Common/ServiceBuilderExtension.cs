using Microsoft.AspNetCore.Identity;

namespace APB.AccessControl.WebApi.Common
{
    internal static class ServiceBuilderExtension
    {
        public static async Task SeedAdminAsync(this IServiceProvider serviceProvider, string username, string password, ILogger logger)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));

            if (await userManager.FindByNameAsync(username) == null)
            {
                var admin = new IdentityUser
                {
                    UserName = username
                };

                var result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
                else
                {
                    logger.LogError("Failed to create admin user: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }
        }

    }
}
