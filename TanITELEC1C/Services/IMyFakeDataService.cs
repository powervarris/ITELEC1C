using TanITELEC1C.Models;
using TanITELEC1C.Services;
namespace TanITELEC1C.Services
{

    public interface IMyFakeDataService
    {

        public List<Student> StudentList { get; }
        public List<Instructor> InstructorList { get; }

    }

}