using BlogWebsite.Database;
using BlogWebsite.Models;
using BlogWebsite.Repositary.CategoryRepositary;
using BlogWebsite.Repositary.CommentRepositary;
using BlogWebsite.Repositary.PostRepositary;
using BlogWebsite.Services.PostService;
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
    options.LoginPath = "/Auth/Login";  
    options.LogoutPath = "/Auth/Logout";
    options.AccessDeniedPath= "/Auth/AccessDenied";
});

// Dependency injection
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPost, PostRepo>();
builder.Services.AddScoped<ICategory, CategoryRepo>();
builder.Services.AddScoped<IComment, CommentClass>();
builder.Services.AddScoped<IdentitySeeder>();


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
  var seeder = scope.ServiceProvider.GetRequiredService<IdentitySeeder>();
    await seeder.SeedAsync(scope.ServiceProvider);

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
