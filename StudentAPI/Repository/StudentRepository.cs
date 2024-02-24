using StudentAPI.Data;
using StudentAPI.Models;

namespace StudentAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDBContext dBContext;

        public StudentRepository(StudentDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
       

        public List<Student> GetAllStudents()
        {
           return dBContext.Students.ToList();
        }

        public void AddStudent(Student student)
        {
            dBContext.Students.Add(student);
            dBContext.SaveChanges();
        }



        public Student DeleteStudent(Guid id)
        {
            var stud =  dBContext.Students.Find(id);
            dBContext.Students.Remove(stud);
            dBContext.SaveChanges();
            return stud;

        }

        public Student UpdateStudent(Guid id, UpdateStudentRequest student)
        {
            var stud = dBContext.Students.Find(id);
            if (stud != null)
            {
                stud.Name = student.Name;
                stud.College = student.College;
                stud.Age = student.Age;
                stud.Marks = student.Marks;

                dBContext.SaveChanges();
            }
            return stud;
        }
    }
}
