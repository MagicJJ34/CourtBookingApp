using CourtBookingApp.Models;
using CourtBookingApp.DTO_s.User;

public static class UserMapping
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Role = user.Role
        };
    }

    public static User ToEntity(this CreateUserDto dto)
    {
        return new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            CreatedAt = DateTime.UtcNow,
            Role = "User"
        };
    }
}