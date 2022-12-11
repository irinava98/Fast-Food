using System.ComponentModel.DataAnnotations;

namespace FastFood.Models
{
    public class LoginViewModel
    {
        [Display(Name = "User Name")]
        [Required]
        [MinLength(4)]
        public string UserName { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required]
        [MinLength(7)]
        public string Password { get; set; } = null!;

        public string ReturnUrl { get; set; } = null!;
    }
}
