using StudentsAPI.Core.Enums;

namespace StudentsAPI.Contracts.StudentContracts
{
    public record StudentsRequest(
    string Name,
    Grade Grade);
}
