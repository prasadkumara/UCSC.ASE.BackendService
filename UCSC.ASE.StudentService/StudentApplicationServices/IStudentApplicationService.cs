using UCSC.ASE.StudentService.StudentModules;

namespace UCSC.ASE.StudentService.StudentApplicationServices
{
    public interface IStudentApplicationService
    {
        List<Student> GetStudents();
        Student GetStudent(int id);
        Student AddStudent(Student student);
        Student? UpdateStudent(Student student);
        bool? DeleteStudent(int id);
    }
}
