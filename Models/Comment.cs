using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlogWebsite.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        [MaxLength(100, ErrorMessage = " UserName cannot exceed 100 characters.")]
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Content is required.")]
        [MaxLength(1000, ErrorMessage = "Content cannot exceed 1000 characters.")]
        public string Content { get; set; }
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
