using BlogWebsite.Database;
using BlogWebsite.Models;

namespace BlogWebsite.Repositary.CommentRepositary
{
    public class CommentClass : IComment
    {
        private readonly AppDbContext _context;
        public CommentClass(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task AddCommentAsync(Comment comment)
        {
           _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }
    }
}
