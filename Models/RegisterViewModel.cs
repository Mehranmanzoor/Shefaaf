using System.ComponentModel.DataAnnotations;

namespace ShefaafSpices.Web.Models
{
    public class RegisterViewModel
    {
     
        [EmailAddress]
        public required string Email { get; set; }

        
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public required string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public required string ConfirmPassword { get; set; }
    }
}