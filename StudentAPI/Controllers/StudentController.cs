using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Data;
using StudentAPI.Models;
using StudentAPI.Repository;
using System.Reflection.Metadata.Ecma335;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDBContext dBContext;
        private readonly IStudentRepository studentRepository;

        public StudentController(StudentDBContext dBContext,IStudentRepository studentRepository)
        {
            this.dBContext = dBContext;
            this.studentRepository = studentRepository;
        }
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok(studentRepository.GetAllStudents());
        }

        [HttpPost]
        public IActionResult AddStudent(AddStudentRequest addStudent)
        {
            var addStud = new Student() { Id = Guid.NewGuid(), Name = addStudent.Name, College = addStudent.College, Age = addStudent.Age, Marks = addStudent.Marks };
            studentRepository.AddStudent(addStud);
            return Ok(addStud);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateStudent([FromRoute] Guid id, UpdateStudentRequest updatestudent) {
            var updatestud = studentRepository.UpdateStudent(id, updatestudent);
            return updatestud != null ? Ok(updatestud) : BadRequest();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteStudent([FromRoute] Guid id) {
             var student= studentRepository.DeleteStudent(id);

            return student!=null ? Ok(student) : NotFound();
        }

    }
}
