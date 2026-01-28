using BlogWebsite.Views.Viewmodels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BlogWebsite.Views.Viewmodels
{
    public class RegisterVM
    {

        [Required(ErrorMessage ="Email is a required field.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="User name is a required field")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
