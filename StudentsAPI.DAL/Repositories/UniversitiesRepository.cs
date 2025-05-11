using Microsoft.EntityFrameworkCore;
using StudentsAPI.Core.Abstractions.UniversityAbstractions;
using StudentsAPI.Core.Models;
using StudentsAPI.DAL.Entities;

namespace StudentsAPI.DAL.Repositories
{
    public class UniversitiesRepository : IUniversitiesRepository
    {
        private readonly StudentsAPIDbContext _context;

        public UniversitiesRepository(StudentsAPIDbContext context)
        {
            _context = context;
        }

        public async Task<List<University>> Get()
        {
            var universityEntities = await _context.Universities
                .AsNoTracking()
                .ToListAsync();

            var universities = universityEntities
                .Select(u => University.Create(u.Id, u.Name).University)
                .ToList();

            return universities;
        }

        public async Task<University> GetById(Guid id)
        {
            var universityEntity = await _context.Universities
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == id);

            if (universityEntity == null)
            {
                throw new Exception("University not found");
            }

            var university = University
                .Create(universityEntity.Id, universityEntity.Name).University;

            return university;
        }

        public async Task<Guid> Add(University university)
        {
            var universityEntity = new UniversityEntity()
            {
                Id = university.Id,
                Name = university.Name
            };
            await _context.AddAsync(universityEntity);
            await _context.SaveChangesAsync();

            return universityEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string name)
        {
            await _context.Universities
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(s => s.
                SetProperty(x => x.Name, name));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Universities
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
    }
}
