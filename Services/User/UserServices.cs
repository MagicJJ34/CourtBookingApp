using CourtBookingApp.Models;
using CourtBookingApp.Data;
using Microsoft.EntityFrameworkCore;
using CourtBookingApp.Services.User;
using CourtBookingApp.DTO_s.User;
using CourtBookingApp.DTOs.User;

namespace CourtBookingApp.Services.User;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Users>CreateUserAsync(CreateUserDto dto)
    {
        var user = new Users
        {
            Name = dto.Name,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            Role = "User"
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<IEnumerable<UserDto>>GetAllAsync()
    {
        var data = await _context.Users.Select(u => new UserDto
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email,
            PhoneNumber = u.PhoneNumber,
            Role = u.Role
        }).ToListAsync();

        return data;
    }

    public async Task<Users>UpdateAsync(int id, UpdateUserDto dto)
    {
        var user = await _context.Users.FindAsync(id);

        user.Name = dto.Name;
        user.Email = dto.Email;
        user.PhoneNumber = dto.PhoneNumber;

        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<UserDto>GetByIdAsync(int id)
    {
        var user = await _context.Users
            .Where(u => u.Id == id)
            .Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Role = u.Role
            })
            .FirstOrDefaultAsync();

        return user;
    }

    public async Task<bool>DeleteAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
}
