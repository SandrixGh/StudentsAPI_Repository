using Microsoft.EntityFrameworkCore;
using StudentsAPI.Core.Enums;
using StudentsAPI.Core.Models;
using StudentsAPI.DAL.Entities;

namespace StudentsAPI.DAL.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly StudentsAPIDbContext _context;

        public StudentsRepository(StudentsAPIDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> Get()
        {
            var studentEntities = await _context.Students
                .AsNoTracking()
                .ToListAsync();

            var students = studentEntities
                .Select(x => Student.Create(x.Id, x.Name, x.Grade).Student)
                .ToList();

            return students;
        }

        public async Task<Guid> Create(Student student)
        {
            var studentEntity = new StudentEntity()
            {
                Id = student.Id,
                Name = student.Name,
                Grade = student.Grade
            };

            await _context.AddAsync(studentEntity);
            await _context.SaveChangesAsync();

            return studentEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string name, Grade grade)
        {
            await _context.Students
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(x => x
                .SetProperty(b => b.Name, b => name)
                .SetProperty(b => b.Grade, b => grade));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Students
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
    }
}
