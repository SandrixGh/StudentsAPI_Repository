using StudentsAPI.Core.Enums;
using StudentsAPI.Core.Models;

namespace StudentsAPI.Application.Services
{
    public interface IStudentsService
    {
        Task<Guid> CreateStudent(Student student);
        Task<Guid> DeleteStudent(Guid id);
        Task<List<Student>> GetAllStudents();
        Task<Guid> UpdateStudent(Guid id, string name, Grade grade);
    }
}