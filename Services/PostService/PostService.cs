using BlogWebsite.Repositary.CategoryRepositary;
using BlogWebsite.Repositary.PostRepositary;
using BlogWebsite.Views.Viewmodels;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace BlogWebsite.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly IWebHostEnvironment _WebHost;
        private readonly IPost _IPost;
        private readonly ICategory _ICategory;

        public PostService(IWebHostEnvironment webHostEnvironment, IPost post, ICategory category)
        {
            _WebHost = webHostEnvironment;
            _IPost = post;
            _ICategory = category;
        }

        public async Task<IEnumerable<SelectListItem>> CategoryList()
        {
            var categoryList = await _ICategory.GetAllCategories();
            return categoryList.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });

        }

        public async Task CreateOrUpdate(PostVM postVM, int? id)
        {
            string wwwRootPath = _WebHost.WebRootPath;
            // Handle image upload ONLY if a new file was provided
            var allowedExt = new[] { ".jpg", ".jpeg", ".png", ".webp", ".jfif" };
            var existingPost = await _IPost.GetPost(u => u.Id == id);
            //validate image.
            if (postVM.FeatureImage != null)
            {
                string extension = Path.GetExtension(postVM.FeatureImage.FileName).ToLower();
                if (!allowedExt.Contains(extension))
                {
                    throw new Exception("FeatureImage, Only jpg, jpeg, png, webp allowed.");
                }

                string folderPath = Path.Combine(wwwRootPath, "images");

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                // Delete old image if exists

                if (existingPost != null && !string.IsNullOrEmpty(existingPost.FeatureImagePath))
                {
                    var oldPath = Path.Combine(wwwRootPath, existingPost.FeatureImagePath.TrimStart('/'));
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


            }
            // If no new image uploaded → keep the existing FeatureImagePath (do nothing)
            else if(existingPost!= null)
            {
                postVM.Post.FeatureImagePath = existingPost.FeatureImagePath;

            }
            if (id == 0 || id == null)
            {
                // Create new
                await _IPost.AddPost(postVM.Post);
            }
            else
            {

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
    }
}

