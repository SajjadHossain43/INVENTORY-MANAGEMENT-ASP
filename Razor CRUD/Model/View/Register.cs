using System.ComponentModel.DataAnnotations;

namespace Razor_CRUD.Model.View
{
    public class Register
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password did not match!")]
        public string ConfirmPassword { get; set; }
    }
}
