using BlogWebsite.Models;
using BlogWebsite.Repositary.PostRepositary;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using BlogWebsite.Views.Viewmodels;
using BlogWebsite.Repositary.CategoryRepositary;

public class PostController : Controller
{
    private readonly IPost _IPost;
    private readonly ICategory _ICategory;
    private readonly IWebHostEnvironment _WebHostEnvironment;
    public PostController(IPost post, ICategory category, IWebHostEnvironment webHostEnvironment)
    {
        _IPost = post;
        _ICategory = category;
        _WebHostEnvironment = webHostEnvironment;
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

    public async Task<IActionResult> CreateUpdate(int? id)
    {

        var categoryList = await _ICategory.GetAllCategories();
        var categorySelect = categoryList.Select(c => new SelectListItem
        {
            Text = c.Name,
            Value = c.Id.ToString()
        });
        PostVM postVM = new PostVM
        {
            Post = new Post(),
            Categories = categorySelect
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
    public async Task<IActionResult> CreateUpdate(PostVM postVM, int? id)
    {
        if (ModelState.IsValid)
        {
            string wwwRootPath = _WebHostEnvironment.WebRootPath;
            // Handle image upload ONLY if a new file was provided
            var allowedExt = new[] { ".jpg", ".jpeg", ".png", ".webp",".jfif" };

            //validate image.
            if (postVM.FeatureImage != null)
            {
                string extension = Path.GetExtension(postVM.FeatureImage.FileName).ToLower();
                if (!allowedExt.Contains(extension))
                {
                    ModelState.AddModelError("FeatureImage", "Only jpg, jpeg, png, webp allowed");
                    return View(postVM);
                }

                string folderPath = Path.Combine(wwwRootPath, "images");

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                // Delete old image if exists
                if (!string.IsNullOrEmpty(postVM.Post?.FeatureImagePath))
                {
                    var oldPath = Path.Combine(wwwRootPath, postVM.Post.FeatureImagePath.TrimStart('/'));
                    if (System.IO.File.Exists(oldPath))
                        System.IO.File.Delete(oldPath);
                }

                // Save new image
              
           
                    string fileName = Guid.NewGuid().ToString() + extension;

                    string filePath = Path.Combine(folderPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await postVM.FeatureImage.CopyToAsync(stream);
                    }

                    postVM.Post.FeatureImagePath = "/images/" + fileName;
                
                // If no new image uploaded → keep the existing FeatureImagePath (do nothing)

                if (id == 0 || id == null)
                {
                    // Create new
                    await _IPost.AddPost(postVM.Post);
                }
                else
                {
                    var existingPost = await _IPost.GetPost(u => u.Id == id);
                    if (existingPost != null)
                    {
                        existingPost.Title = postVM.Post.Title;
                        existingPost.Author = postVM.Post.Author;
                        existingPost.Content = postVM.Post.Content;
                        existingPost.CategoryId = postVM.Post.CategoryId;
                        existingPost.FeatureImagePath = postVM.Post.FeatureImagePath;
                    }
                    // Update existing
                    await _IPost.UpdatePost(existingPost);
                }
            }
               

            return RedirectToAction(nameof(Index));
        }

        // If model invalid, reload categories
        var categoryList = await _ICategory.GetAllCategories();
        postVM.Categories = categoryList.Select(c => new SelectListItem
        {
            Text = c.Name,
            Value = c.Id.ToString()
        });

        return View(postVM);
    }
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