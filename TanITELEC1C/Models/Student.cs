using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TanITELEC1C.Models
{

    public enum Course
    {
        CS, IT, IS
    }

    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter your First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter your Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter your Course")]
        [Display(Name = "Course")]
        public Course Course { get; set; }

        [Display(Name = "Date Enrolled")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please Enter your Date Enrolled")]
        public DateTime dateEnrolled { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Please Enter your Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /**[Display(Name = "Profile Picture")]
        public byte[]? StudentProfilePhoto { get; set; }**/

        [NotMapped]
        public IFormFile? UploadPhoto { get; set; }
        [Display(Name="Profile Picture")]
        public string? imagePath { get; set; }


    }
}
