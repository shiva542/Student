using StudentAPI.Models;

namespace StudentAPI.Repository
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();

        void AddStudent(Student student);

        Student UpdateStudent(Guid id, UpdateStudentRequest student);    

        Student DeleteStudent(Guid id);

    }
}
