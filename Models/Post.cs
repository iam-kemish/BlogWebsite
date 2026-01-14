using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BlogWebsite.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(200, ErrorMessage = "Title cannot exceed 200 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required")]
       
        public string Content { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [MaxLength(100, ErrorMessage = "Name cannot be more than 100 characters.")]
        public string Author { get; set; }

        public string? FeatureImagePath { get; set; }

        public DateTime PublishedDate { get; set; } = DateTime.Now;
        [DisplayName("Category")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public string? ImageUrl { get; set; } = "/images/posts/default.jpg";

    }
}
