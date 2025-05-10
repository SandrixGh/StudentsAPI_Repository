using StudentsAPI.Core.Enums;

namespace StudentsAPI.DAL.Entities
{
    public class StudentEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Grade Grade { get; set; }
    }
}
