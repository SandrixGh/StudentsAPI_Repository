using StudentsAPI.Core.Enums;
using StudentsAPI.Core.Models;

namespace StudentsAPI.DAL.Repositories
{
    public interface IStudentsRepository
    {
        Task<Guid> Create(Student student);
        Task<Guid> Delete(Guid id);
        Task<List<Student>> Get();
        Task<Guid> Update(Guid id, string name, Grade grade);
    }
}