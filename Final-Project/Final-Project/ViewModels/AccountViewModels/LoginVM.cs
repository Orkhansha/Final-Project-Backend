using System.ComponentModel.DataAnnotations;

namespace Final_Project.ViewModels.AccountViewModels
{
    public class LoginVM
    {
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
