using StudentsAPI.Core.Enums;

namespace StudentsAPI.Contracts.StudentContracts
{
    public record StudentsResponse(
        Guid Id,
        string Name,
        Grade Grade);
}
