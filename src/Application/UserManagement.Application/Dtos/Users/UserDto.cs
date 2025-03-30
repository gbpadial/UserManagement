using UserManagement.Domain.Entities.Users;

namespace UserManagement.Application.Dtos.Users;

public record UserDto(
    Guid? Id = null,
    string? Email = null,
    string? Name = null,
    string? ZipCode = null,
    string? Address = null)
{
    public static UserDto FromEntity(User user)
        => new(
            user.Id,
            user.Email,
            user.Name,
            user.ZipCode,
            user.Address);
};