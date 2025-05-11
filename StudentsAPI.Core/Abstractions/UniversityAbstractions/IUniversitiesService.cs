using StudentsAPI.Core.Models;

namespace StudentsAPI.Core.Abstractions.UniversityAbstractions
{
    public interface IUniversitiesService
    {
        Task<Guid> AddUniversity(University university);
        Task<Guid> DeleteUniversity(Guid id);
        Task<List<University>> GetAllUniversities();
        Task<University> GetUniversityById(Guid id);
        Task<Guid> UpdateUniversity(Guid id, string name);
    }
}