using BlogWebsite.Views.Viewmodels;

namespace BlogWebsite.Services.PostService
{
    public interface IPostService
    {
        Task CreateOrUpdate(PostVM postVM, int? id);
       
    }
}
