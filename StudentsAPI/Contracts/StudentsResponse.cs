using StudentsAPI.Core.Enums;

namespace StudentsAPI.Contracts
{
    public record StudentsResponse(
        Guid Id,
        string Name,
        Grade Grade);
}
