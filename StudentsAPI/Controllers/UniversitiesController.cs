using Microsoft.AspNetCore.Mvc;
using StudentsAPI.Contracts.UniversityContracts;
using StudentsAPI.Core.Abstractions.UniversityAbstractions;
using StudentsAPI.Core.Models;

namespace StudentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : ControllerBase
    {
        private readonly IUniversitiesService _universitiesService;

        public UniversitiesController(IUniversitiesService universitiesService)
        {
            _universitiesService = universitiesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UniversitiesResponse>>> GetAllUniversities()
        {
            var universities = await _universitiesService.GetAllUniversities();

            var response = universities.Select(x => new UniversitiesResponse(x.Id, x.Name));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UniversitiesResponse>> GetUniversityById(Guid id)
        {
            var university = await _universitiesService.GetUniversityById(id);

            var response = new UniversitiesResponse(id, university.Name);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> AddUniversity([FromBody] UniversitiesRequest request)
        {
            var (university, error) = University.Create(
                Guid.NewGuid(),
                request.Name);

            if(!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var universityId = await _universitiesService.AddUniversity(university);

            return Ok(universityId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateUniversity(Guid id, [FromBody] UniversitiesRequest request)
        {
            var (university, error) = University.Create(
                id,
                request.Name);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            await _universitiesService.UpdateUniversity(id, university.Name);

            return Ok(id);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteUniversity(Guid id)
        {
            return Ok(await _universitiesService.DeleteUniversity(id));
        }
    }
}
