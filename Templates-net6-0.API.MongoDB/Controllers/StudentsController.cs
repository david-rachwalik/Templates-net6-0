namespace Templates_net6_0.API.MongoDB.Controllers;
using Microsoft.AspNetCore.Mvc;
using Templates_net6_0.API.MongoDB.Models;
using Templates_net6_0.API.MongoDB.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentService studentService;

    public StudentsController(IStudentService studentService)
    {
        this.studentService = studentService;
    }

    // GET: api/<StudentController>
    [HttpGet]
    public ActionResult<IEnumerable<Student>> Get()
    {
        return studentService.Get();
    }

    // GET api/<StudentController>/5
    [HttpGet("{id}")]
    public ActionResult<Student> Get(string id)
    {
        var student = studentService.Get(id);
        if (student == null)
        {
            return NotFound($"Student with Id = {id} not found");
        }
        return student;
    }

    // POST api/<StudentController>
    [HttpPost]
    public ActionResult<Student> Post([FromBody] Student student)
    {
        studentService.Create(student);
        return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
    }

    // PUT api/<StudentController>/5
    [HttpPut("{id}")]
    public ActionResult<Student> Put(string id, [FromBody] Student student)
    {
        var existingStudent = studentService.Get(id);
        if (existingStudent == null)
        {
            return NotFound($"Student with Id = {id} not found");
        }
        studentService.Update(id, student);
        return NoContent();
    }

    // DELETE api/<StudentController>/5
    [HttpDelete("{id}")]
    public ActionResult<Student> Delete(string id)
    {
        var student = studentService.Get(id);
        if (student == null)
        {
            return NotFound($"Student with Id = {id} not found");
        }
        studentService.Remove(student.Id);
        return Ok($"Student with Id = {id} deleted");
    }
}
