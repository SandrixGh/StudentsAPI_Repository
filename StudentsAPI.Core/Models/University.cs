namespace StudentsAPI.Core.Models
{
    public class University
    {
        public const int MAX_NAME_LENGTH = 100;

        private University(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }

        public static (University University, string Error) Create(Guid id, string name)
        {
            var error = string.Empty;

            if(string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
            {
                error = $"Name can not be empty or longer then {MAX_NAME_LENGTH} symbols";
            }

            var university = new University(id, name);

            return(university, error);
        }
    }
}
