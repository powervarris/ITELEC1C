using System.ComponentModel.DataAnnotations;

namespace TanITELEC1C.ViewModels
{
    public class RegisterViewModel
    {

        //Username
        [Display(Name = "User Name")]
        [Required(ErrorMessage ="Please enter your user name")]
        public string? Username { get; set; }

        //Password
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Please enter your password")]
        public string? Password { get; set; }

        //Confirm Password
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="You must confirm your password")]
        public string? ConfirmPassword { get; set; }

        //First Name
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter your first name")]
        public string? FirstName { get; set; }

        //Last Name
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter your last name")]
        public string? LastName { get; set; }

        //Email
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter your email address")]
        public string? Email { get; set; }

        //Phone
        [Display(Name = "Phone Number")]
        [RegularExpression("[0-9]{2}-[0-9]{3}-[0-9]{4}", ErrorMessage ="you must follow the format 00-000-0000")]
        public string? Phone { get; set; }

    }
}
