using Microsoft.AspNetCore.Mvc;

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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsTenured { get; set; }
        public Rank Rank { get; set; }
        public Status Status { get; set; }
        public DateTime HiringDate { get; set; }


    }
}
