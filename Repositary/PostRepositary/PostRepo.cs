using BlogWebsite.Database;
using BlogWebsite.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogWebsite.Repositary.PostRepositary
{
    public class PostRepo : IPost
    {
        private readonly AppDbContext _context;

        public PostRepo(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task AddPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePost(Post post)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            return await _context.Posts
                    .Include(p => p.Comments)
                    .Include(p => p.Category)
                    .ToListAsync();
        }

        public async Task<Post?> GetPost(Expression<Func<Post, bool>>? filter)
        {

            return await _context.Posts.Where(filter).FirstOrDefaultAsync();
        }

        public async Task UpdatePost(Post post)
        {
            _context.Update(post);
            await _context.SaveChangesAsync();
        }
    }
}
