using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsAPI.Contracts.StudentContracts;
using StudentsAPI.Core.Abstractions.StudentAbstractions;
using StudentsAPI.Core.Models;

namespace StudentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentsResponse>>> GetStudents()
        {
            var students = await _studentsService.GetAllStudents();

            var response = students.Select(b => new StudentsResponse(b.Id, b.Name, b.Grade));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> AddStudent([FromBody] StudentsRequest request)
        {
            var (student, error) = Student.Create(
                Guid.NewGuid(),
                request.Name,
                request.Grade);

            if(!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var studentId = await _studentsService.AddStudent(student);

            return Ok(studentId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateStudent(Guid id, [FromBody] StudentsRequest request)
        {
            var (student, error) = Student.Create(
                id,
                request.Name,
                request.Grade);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var studentId = await _studentsService.UpdateStudent(id, request.Name, request.Grade);

            return Ok(studentId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteStudent(Guid id)
        {
            return Ok(await _studentsService.DeleteStudent(id));
        }
    }
}
