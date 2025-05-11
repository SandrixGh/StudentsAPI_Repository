using StudentsAPI.Core.Abstractions.UniversityAbstractions;
using StudentsAPI.Core.Models;

namespace StudentsAPI.Application.Services
{
    public class UniversitiesService : IUniversitiesService
    {
        private readonly IUniversitiesRepository _universitiesRepository;

        public UniversitiesService(IUniversitiesRepository universitiesRepository)
        {
            _universitiesRepository = universitiesRepository;
        }

        public async Task<List<University>> GetAllUniversities()
        {
            return await _universitiesRepository.Get();
        }

        public async Task<University> GetUniversityById(Guid id)
        {
            return await _universitiesRepository.GetById(id);
        }

        public async Task<Guid> AddUniversity(University university)
        {
            return await _universitiesRepository.Add(university);
        }

        public async Task<Guid> UpdateUniversity(Guid id, string name)
        {
            return await _universitiesRepository.Update(id, name);
        }

        public async Task<Guid> DeleteUniversity(Guid id)
        {
            return await _universitiesRepository.Delete(id);
        }
    }
}
