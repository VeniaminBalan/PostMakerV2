using System.ComponentModel.DataAnnotations;

namespace PostMakerV2.Models
{
    public class SignupViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Password confirmation")]
        public string PasswordConfirm { get; set ; }
    }
}
