using UCSC.ASE.StudentService.StudentDataServices;
using UCSC.ASE.StudentService.StudentModules;
using UCSC.ASE.StudentService.DatabaseModules;

namespace UCSC.ASE.StudentService.StudentApplicationServices
{
    public class StudentApplicationService : IStudentApplicationService
    {
        DatabaseContext _db;
        public StudentApplicationService(DatabaseContext db)
        {
            _db = db;
        }

        public List<Student> GetStudents()
        {
            return StudentDataService.GetStudent(_db);
        }

        public Student GetStudent(int id)
        {
            return StudentDataService.GetStudent(_db, id);
        }

        public Student AddStudent(Student student)
        {
            return StudentDataService.AddStudent(_db, student);
        }

        public Student? UpdateStudent(Student student)
        {
            return StudentDataService.UpdateStudent(_db, student);
        }

        public bool? DeleteStudent(int id)
        {
            return StudentDataService.DeleteStudent(_db, id);
        }
    }
}
