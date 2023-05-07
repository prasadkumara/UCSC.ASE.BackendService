using UCSC.ASE.StudentService.DatabaseModules;
using UCSC.ASE.StudentService.StudentModules;

namespace UCSC.ASE.StudentService.StudentDataServices
{
    public class StudentDataService
    {
        public static List<Student> GetStudent(DatabaseContext _db)
        {
            return _db.Students.ToList();
        }

        public static Student GetStudent(DatabaseContext _db, int id)
        {
            return _db.Students.First(student => student.Id == id);
        }

        public static Student AddStudent(DatabaseContext _db, Student student)
        {
             _db.Students.Add(student);
            _db.SaveChanges();
            return student;
        }

        public static Student UpdateStudent(DatabaseContext _db, Student student)
        {
            Student? student_ = _db.Students.FirstOrDefault(x => x.Id == student.Id);
            if (student_ != null)
            {
                student_.Name = student.Name;
                student_.Address = student.Address;
                student_.Email = student.Email;
                student_.MobileNo = student.MobileNo;
                student_.Batch = student.Batch;
                _db.SaveChanges();
            }
            return student;
        }

        public static bool? DeleteStudent(DatabaseContext _db,  int id)
        {
            Student? selectedStudent = _db.Students.FirstOrDefault(x => x.Id == id);
            if (selectedStudent != null)
            {
                _db.Students.Remove(selectedStudent);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
