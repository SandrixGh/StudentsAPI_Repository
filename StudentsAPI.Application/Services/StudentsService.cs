using StudentsAPI.Core.Abstractions.StudentAbstractions;
using StudentsAPI.Core.Enums;
using StudentsAPI.Core.Models;

namespace StudentsAPI.Application.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentsRepository _repository;

        public StudentsService(IStudentsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _repository.Get();
        }

        public async Task<Guid> AddStudent(Student student)
        {
            return await _repository.Add(student);
        }

        public async Task<Guid> UpdateStudent(Guid id, string name, Grade grade)
        {
            return await _repository.Update(id, name, grade);
        }

        public async Task<Guid> DeleteStudent(Guid id)
        {
            return await _repository.Delete(id);
        }
    }
}
