using System;
using System.Security.Cryptography.X509Certificates;
using TanITELEC1C.Models;
using TanITELEC1C.Services;


namespace TanITELEC1C.Services
{
    public class MyFakeDateService : IMyFakeDataService
    {

        public List<Student> StudentList { get; }

        public List<Instructor> InstructorList { get; }

        public MyFakeDateService()
        {
            StudentList = new List<Student> {

            new Student()
            {
                Id = 1,
                FirstName = "John Paolo",
                LastName = "Tan",
                Course = Course.IT,
                dateEnrolled = DateTime.Parse("24/07/2021"),
                Email = "johnpaolo.tan.cics@ust.edu.ph"

            },
            new Student()
            {
                Id = 2,
                FirstName = "Ryan",
                LastName = "Dy",
                Course = Course.CS,
                dateEnrolled = DateTime.Parse("24/07/2021"),
                Email = "ryan.dy.cics@ust.edu.ph"
            },
            new Student()
            {
                Id = 3,
                FirstName = "Herald",
                LastName = "Oliveros",
                Course = Course.IS,
                dateEnrolled = DateTime.Parse("24/07/2021"),
                Email = "herald.oliveros.cics@ust.edu.ph"
            }

        };



            InstructorList = new List<Instructor>
            {

                new Instructor()
            {
                Id= 1,FirstName = "Gabriel", LastName = "Montano", Rank = Rank.Professor, HiringDate = DateTime.Parse("24/01/2020"), IsTenured = true
            },
            new Instructor()
            {
                Id= 2,FirstName = "Beatriz", LastName = "Lacsamana", Rank = Rank.AssistantProfessor, HiringDate = DateTime.Parse("17/04/2017"), IsTenured = false
            },
            new Instructor()
            {
                Id= 3,FirstName = "Ronina", LastName = "Tayuan", Rank = Rank.AssociateProfessor, HiringDate = DateTime.Parse("12/07/2019"), IsTenured = false
            }

            };


        }

    }
}