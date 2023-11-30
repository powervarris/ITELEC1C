using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TanITELEC1C.Models
{
    public enum Rank
    {
        Instructor, AssistantProfessor, AssociateProfessor, Professor
    }

    public enum Status
    {
        Provisionary, Permanent
    }
    public class Instructor
    {
        [Key]
        public int Id { get; set; }

        //First Name
        [Required(ErrorMessage = "Pleae Enter your First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        //Last Name
        [Required(ErrorMessage = "Please Enter your Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public bool IsTenured { get; set; }


        //Academic Rank
        [Required(ErrorMessage = "Please Enter your Academic Rank")]
        [Display(Name = "Academic Rank")]
        public Rank Rank { get; set; }

        //Status
        [Required(ErrorMessage = "Please Enter your Status")]
        [Display(Name = "Status")]
        public Status Status { get; set; }


        //Date Hired
        [Display(Name = "Date Hired")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please Enter your Date Hired")]
        public DateTime HiringDate { get; set; }

        
        //Email Address
        [EmailAddress]
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please Enter your Email Address")]
        public string? email { get; set; }


        //Phone Number
        [Phone]
        /**[RegularExpression("[0-9]{4} - [0-9]{3} - [0-9]{4}", ErrorMessage = "You must follow this format 0000-000-0000")]**/
        [Display(Name = "Phone Number")]
        public string? phone { get; set; }

        /**[Display(Name = "Profile Picture")]
        public byte[]? StudentProfilePhoto { get; set; }**/

        [NotMapped]
        public IFormFile? UploadPhoto { get; set; }
        [Display(Name = "Profile Picture")]
        public string? imagePath { get; set; }
        

    }
}
