using BlogWebsite.Models;

namespace BlogWebsite.Repositary.CommentRepositary
{
    public interface IComment
    {
        Task AddCommentAsync(Comment comment);
    }
}
