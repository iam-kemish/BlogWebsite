using System.ComponentModel.DataAnnotations;

namespace BlogWebsite.Views.Viewmodels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email is a required field.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }

    }
}
