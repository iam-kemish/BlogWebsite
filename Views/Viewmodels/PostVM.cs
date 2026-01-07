using BlogWebsite.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogWebsite.Views.Viewmodels
{
    public class PostVM
    {
        public Post? Post { get; set; }
        public IEnumerable<Post>? Posts { get; set; } = new List<Post>();
        public IEnumerable<SelectListItem>? Categories { get; set; }
        public IFormFile? FeatureImage { get; set; }
    }
}
