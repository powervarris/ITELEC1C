using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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

        public int Id { get; set; }

        //First Name
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }


        //Last Name
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please Enter your Last Name")]
        public string LastName { get; set; }
        public bool IsTenured { get; set; }


        //Academic Rank
        [Display(Name = "Academic Rank")]
        public Rank Rank { get; set; }

        //Status
        public Status Status { get; set; }


        //Date Hired
        [Display(Name = "Date Hired")]
        public DateTime HiringDate { get; set; }

        
        //Email Address
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string? email { get; set; }


        //Phone Number
        [Phone]
        [RegularExpression("[0-9]{2} - [0-9]{3} - [0-9]{4}", ErrorMessage = "You must follow this format 00-000-0000")]
        public string? phone { get; set; }


    }
}
