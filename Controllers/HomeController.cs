using System.Diagnostics;
using System.Linq.Expressions;
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

        public async Task<IActionResult> Index(int? categoryId, int PageNumber=1)
        {

           
            int pageSize = 10;
            Expression<Func<Post, bool>>? filter = categoryId == null ? null : u => u.CategoryId == categoryId;
            var result = await _IPost.GetPagedPosts(filter, pageSize, PageNumber);
            HomeVM homeVM = new()
            {
                CategoryId = categoryId,
                Posts = result.Item1,
                TotalPages = (int)Math.Ceiling(result.TotalCount / (double)pageSize),
                Categories = await _ICategory.GetAllCategories(),
                CurrentPage= PageNumber
            };
            return View(homeVM);
        }
    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
