using BlogWebsite.Views.Viewmodels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogWebsite.Services.PostService
{
    public interface IPostService
    {
        Task CreateOrUpdate(PostVM postVM, int? id);
        Task<IEnumerable<SelectListItem>> CategoryList();
       
    }
}
