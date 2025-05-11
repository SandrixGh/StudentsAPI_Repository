using StudentsAPI.Core.Models;

namespace StudentsAPI.Core.Abstractions.UniversityAbstractions
{ 
    public interface IUniversitiesRepository
    {
        Task<Guid> Add(University university);
        Task<Guid> Delete(Guid id);
        Task<List<University>> Get();
        Task<University> GetById(Guid id);
        Task<Guid> Update(Guid id, string name);
    }
}