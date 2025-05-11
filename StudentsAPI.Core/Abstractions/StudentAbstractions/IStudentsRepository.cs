using StudentsAPI.Core.Enums;
using StudentsAPI.Core.Models;

namespace StudentsAPI.Core.Abstractions.StudentAbstractions
{
    public interface IStudentsRepository
    {
        Task<Guid> Add(Student student);
        Task<Guid> Delete(Guid id);
        Task<List<Student>> Get();
        Task<Guid> Update(Guid id, string name, Grade grade);
    }
}