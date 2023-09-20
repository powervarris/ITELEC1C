using Microsoft.AspNetCore.Mvc;

namespace TanITELEC1C.Models
{

    public enum Course
    {
        CS, IT, IS
    }

    public class Student
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Course Course { get; set; }
        public DateTime dateEnrolled { get; set; }
        public string Email { get; set; }


    }
}
