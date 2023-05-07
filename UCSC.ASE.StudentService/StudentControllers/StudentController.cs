using Microsoft.AspNetCore.Mvc;
using UCSC.ASE.StudentService.StudentApplicationServices;
using UCSC.ASE.StudentService.StudentModules;

namespace UCSC.ASE.StudentService.StudentControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentApplicationService _studentService;

        public StudentController(IStudentApplicationService studentService)
        {
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_studentService.GetStudents());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return _studentService.GetStudent(id) != null ? Ok(_studentService.GetStudent(id)) : NoContent();
            }
            catch (Exception ex)
            {
                return  BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            try
            {
                return Ok(_studentService.AddStudent(student));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Student student)
        {
            try
            {
                return Ok(_studentService.UpdateStudent(student));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _studentService.DeleteStudent(id);

                return result.HasValue & result == true ? Ok($"student with ID:{id} got deleted successfully.")
                    : BadRequest($"Unable to delete the student with ID:{id}.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
