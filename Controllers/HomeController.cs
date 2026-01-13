using System.Diagnostics;
using BlogWebsite.Models;
using BlogWebsite.Repositary.CategoryRepositary;
using BlogWebsite.Repositary.PostRepositary;
using BlogWebsite.Views.Viewmodels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BlogWebsite.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPost _IPost;
        private readonly ICategory _ICategory;

        public HomeController(IPost post, ICategory category)
        {
            _IPost = post;
            _ICategory = category;
        }

        public async Task<IActionResult> Index(int? categoryId)
        {
            HomeVM homeVM = new();
            
               if (categoryId == null)
            {
                homeVM.Posts = await _IPost.GetAllPosts();
            }
            else
            {
                homeVM.Posts = await _IPost.GetAllPosts(u => u.CategoryId == categoryId);
            }

            homeVM.Categories = await _ICategory.GetAllCategories();

            return View(homeVM);
    }
    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
