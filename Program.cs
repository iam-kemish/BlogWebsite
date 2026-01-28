using BlogWebsite.Database;
using BlogWebsite.Models;
using BlogWebsite.Repositary.CategoryRepositary;
using BlogWebsite.Repositary.CommentRepositary;
using BlogWebsite.Repositary.PostRepositary;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Identity setup
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
    options.Lockout.AllowedForNewUsers = true;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

// Configure cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // max for persistent login
    options.SlidingExpiration = true;
    options.LoginPath = "/Auth/Login";   // redirect if unauthorized
    options.LogoutPath = "/Auth/Logout";
});

// Dependency injection
builder.Services.AddScoped<IPost, PostRepo>();
builder.Services.AddScoped<ICategory, CategoryRepo>();
builder.Services.AddScoped<IComment, CommentClass>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var _userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    var _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var adminEmail = builder.Configuration["Admin:Email"];
    var adminPassword = builder.Configuration["Admin:Password"];
    var adminUserName = builder.Configuration["Admin:Username"];
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


// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ✅ Identity middlewares
app.UseAuthentication();   // must be before authorization
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
