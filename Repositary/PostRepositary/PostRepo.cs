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

        public async Task<IEnumerable<Post>> GetAllPosts(Expression<Func<Post, bool>>? filter = null)
        {
            var query =   _context.Posts
                    .Include(p => p.Comments)
                    .Include(p => p.Category).Where(filter)
                    .AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();  
        }

        public async Task<Post?> GetPost(Expression<Func<Post, bool>>? filter = null)
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
