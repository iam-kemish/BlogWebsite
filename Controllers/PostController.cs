using BlogWebsite.Models;
using BlogWebsite.Repositary.PostRepositary;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using BlogWebsite.Views.Viewmodels;
using BlogWebsite.Repositary.CategoryRepositary;
using Microsoft.AspNetCore.Authorization;
using BlogWebsite.Services.PostService;


public class PostController : Controller
{
    private readonly IPost _IPost;
    private readonly ICategory _ICategory;
    private readonly IPostService _IPostSerice;
   
    public PostController(IPost post, ICategory category, IPostService postService)
    {
        _IPost = post;
        _ICategory = category;
        _IPostSerice = postService;
      
    }
    public async Task<IActionResult> Index(int PageNumber=1)
    {
        int pageSize = 10;
        var result = await _IPost.GetPagedPosts(filter:null, pageSize, PageNumber);
        PostVM postVM = new()
        {
            Posts = result.Item1,
            CurrentPage= PageNumber,
            TotalPages = (int)Math.Ceiling(result.TotalCount / (double)pageSize)
        };
        return View(postVM);
    }
    [Authorize(Roles ="Admin")]
    public async Task<IActionResult> CreateUpdate(int? id)
    {

        var categoryList = await _ICategory.GetAllCategories();

        PostVM postVM = new PostVM
        {
            Post = new Post(),
            Categories = await _IPostSerice.CategoryList()
        };
        if (id == null || id == 0)
        {

            return View(postVM);
        }
        postVM.Post = await _IPost.GetPost(u => u.Id == id);
        if (postVM.Post == null)
        {
            return NotFound();
        }
        return View(postVM);

    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateUpdate(PostVM postVM, int? id)
    {
        if (!ModelState.IsValid)
        {
            // If model invalid, reload categories
            await _IPostSerice.CategoryList();

        }
       await _IPostSerice.CreateOrUpdate(postVM, id);
        
        return RedirectToAction(nameof(Index));
    }
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || id == 0)
        {

            return RedirectToAction("ErrorViewModel");
        }
        Post? post = await _IPost.GetPost(u => u.Id == id);
        if (post == null)
        {
            return RedirectToAction("Index");
        }
        return View(post);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var PostToDelete = await _IPost.GetPost(u => u.Id == id);
        if (PostToDelete == null)
        {
            return RedirectToAction("Index");
        }
        await _IPost.DeletePost(PostToDelete);
        return RedirectToAction("Index");
    }

}