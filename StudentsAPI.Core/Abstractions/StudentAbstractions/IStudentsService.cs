using StudentsAPI.Core.Enums;
using StudentsAPI.Core.Models;

namespace StudentsAPI.Core.Abstractions.StudentAbstractions
{
    public interface IStudentsService
    {
        Task<Guid> AddStudent(Student student);
        Task<Guid> DeleteStudent(Guid id);
        Task<List<Student>> GetAllStudents();
        Task<Guid> UpdateStudent(Guid id, string name, Grade grade);
    }
}