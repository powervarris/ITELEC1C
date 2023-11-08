using Microsoft.EntityFrameworkCore;
using TanITELEC1C.Models;

namespace TanITELEC1C.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Student> Students { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    FirstName = "John Paolo",
                    LastName = "Tan",
                    Course = Course.IT,
                    dateEnrolled = DateTime.Parse("2021-08-02"),
                    Email = "johnpaolotan@gmail.com"
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Ryan",
                    LastName = "Dy",
                    Course = Course.IS,
                    dateEnrolled = DateTime.Parse("2020-05-09"),
                    Email = "ryandy@gmail.com"
                },
                new Student()
                {
                    Id = 3,
                    FirstName = "Herald",
                    LastName = "Oliveros",
                    Course = Course.CS,
                    dateEnrolled = DateTime.Parse("2022-04-12"),
                    Email = "heraldoliveros@gmail.com",
                });

            modelBuilder.Entity<Instructor>().HasData
                (new Instructor()
                {
                    Id = 1,
                    FirstName = "Beatrice",
                    LastName = "Lacasmana",
                    Status = Status.Permanent,
                    HiringDate = DateTime.Now,
                    email = "beatricelacsamana@ust.edu.ph",
                    Rank = Rank.Instructor
                },

            new Instructor()
            {
                Id = 2,
                FirstName = "Gabriel",
                LastName = "Montano",
                Status = Status.Permanent,
                HiringDate = DateTime.Parse("20,2,2023"),
                email = "gdmontano@ust.edu.ph",
                Rank = Rank.AssistantProfessor
            },

            new Instructor()
            {
                Id = 3,
                FirstName = "Bernard",
                LastName = "Sanidad",
                Status = Status.Provisionary,
                HiringDate = DateTime.Parse("10,4,2021"),
                email = "bernardsanidad@ust.edu.ph",
                Rank = Rank.Professor
            });

        }
    }
}
