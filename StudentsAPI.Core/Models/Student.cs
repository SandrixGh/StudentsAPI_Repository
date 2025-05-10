using StudentsAPI.Core.Enums;

namespace StudentsAPI.Core.Models
{
    public class Student
    {
        public const int MAX_NAME_LENGTH = 50;

        private Student(Guid id, string name, Grade grade)
        {
            Id = id;
            Name = name;
            Grade = grade;
        }

        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public Grade Grade { get; }

        public static (Student Student, string Error) Create(Guid id, string name, Grade grade)
        {
            var error = string.Empty;

            if(string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
            {
                error = $"Title can not be empty or longer then {MAX_NAME_LENGTH} symbols";
            }

            var student = new Student(id, name, grade);

            return (student, error);    
        }
    }
}
