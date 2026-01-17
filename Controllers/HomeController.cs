using System.Diagnostics;
using System.Linq.Expressions;
using BlogWebsite.Models;
using BlogWebsite.Repositary.CategoryRepositary;
using BlogWebsite.Repositary.CommentRepositary;
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
        private readonly IComment _IComment;

        public HomeController(IPost post, ICategory category, IComment comment)
        {
            _IPost = post;
            _ICategory = category;
            _IComment = comment;
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
       public async Task<IActionResult> Details(int PostId)
        {
            var newpost = await _IPost.GetPost(u => u.Id == PostId);
            if(newpost == null)
            {
                return NotFound();
            }
            PostDetailsVM postDetails = new()
            {
                post = newpost,
                comment = new Comment
                {
                    PostId = newpost.Id
                }
            };
            return View(postDetails);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                await _IComment.AddCommentAsync(comment);

                return RedirectToAction(nameof(Details), new {postId = comment.PostId});
            }
            return RedirectToAction(nameof(Details), new { PostId = comment.PostId });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
