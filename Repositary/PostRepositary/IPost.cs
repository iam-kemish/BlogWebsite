using System.Linq.Expressions;
using BlogWebsite.Models;

namespace BlogWebsite.Repositary.PostRepositary
{
    public interface IPost
    {
        Task<IEnumerable<Post>> GetAllPosts(Expression<Func<Post, bool>>? filter = null);
        Task<Post?> GetPost(Expression<Func<Post, bool>>? filter =null);
        Task AddPost(Post post);
        Task UpdatePost(Post post);
        Task DeletePost(Post post);
    }
}
