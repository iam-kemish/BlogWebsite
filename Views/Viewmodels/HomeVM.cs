using BlogWebsite.Models;

namespace BlogWebsite.Views.Viewmodels
{
    public class HomeVM
    {
        public IEnumerable<Post>? Posts { get; set; } = new List<Post>();
        public IEnumerable< Category?>? Categories { get; set; } 
    }
}
