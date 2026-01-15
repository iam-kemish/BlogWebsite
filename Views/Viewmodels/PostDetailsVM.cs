using BlogWebsite.Models;

namespace BlogWebsite.Views.Viewmodels
{
    public class PostDetailsVM
    {
        public Post? post { get; set; }  
        public Comment? comment { get; set; }
    }
}
