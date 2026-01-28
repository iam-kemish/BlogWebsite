using BlogWebsite.Models;
using BlogWebsite.Views.Viewmodels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signinManager;

        public AuthController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signinManager = signInManager;
            
        }
        [HttpGet]
       public  IActionResult Register()
        {
         return  View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {

            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = registerVM.UserName,
                    Email = registerVM.Email,

                };
                var result = await _userManager.CreateAsync(user, registerVM.Password);
                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync(StaticDetails.Role_Customer).GetAwaiter().GetResult())
                    {
                        _roleManager.CreateAsync(new IdentityRole(StaticDetails.Role_Customer)).GetAwaiter().GetResult();
                    }
                    //default role is given as Costumer,i.e. General users.
                    _userManager.AddToRoleAsync(user, StaticDetails.Role_Customer).GetAwaiter().GetResult();
                    //we will sign the user in now, the second parameter ispersistant :true, means the user will be logged in even after browser is closed.
                    _signinManager.SignInAsync(user, isPersistent: false).GetAwaiter().GetResult();
                    return RedirectToAction("Index", "Home");


                }
            }
            return View(registerVM);
        }
       
    }
}
