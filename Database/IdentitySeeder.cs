using BlogWebsite.Models;
using Microsoft.AspNetCore.Identity;

namespace BlogWebsite.Database
{
    public  class IdentitySeeder
    {
        private readonly IConfiguration _config;

        public IdentitySeeder(IConfiguration configuration)
        {
            _config = configuration;    
        }
        public  async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            var _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var adminEmail = _config["Admin:Email"];
            var adminPassword = _config["Admin:Password"];
            var adminUserName = _config["Admin:Username"];
            var roleName = "Admin";

            var existingAdminRole = await _roleManager.FindByNameAsync(roleName);

            if (existingAdminRole == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName));
            }

            var existingAdminUser = await _userManager.FindByEmailAsync(adminEmail);

            if (existingAdminUser == null)
            {
                var adminUser = new AppUser()
                {
                    UserName = adminUserName,
                    Email = adminEmail,
                    EmailConfirmed = true

                };
                var createUser = await _userManager.CreateAsync(adminUser, adminPassword);
                if (createUser.Succeeded)
                {
                    await _userManager.AddToRoleAsync(adminUser, roleName);
                }
            }

        }
    }
}
