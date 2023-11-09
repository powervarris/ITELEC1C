using System.ComponentModel.DataAnnotations;

namespace TanITELEC1C.ViewModels
{
    public class LoginViewModel
    {

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is Invalid")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is Invalid")]
        public string Password { get; set; }

        //Remember me
        [Display(Name = "Remember Me")]
        [Required(ErrorMessage ="Remember Me Failed")]
        public bool RememberMe { get; set; }

        

    }
}
