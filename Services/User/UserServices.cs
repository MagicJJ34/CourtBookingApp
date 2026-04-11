using CourtBookingApp.Models;
using CourtBookingApp.Data;
using Microsoft.EntityFrameworkCore;
using CourtBookingApp.Services.User;
using CourtBookingApp.DTO_s.User;

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

    public async Task<IEnumerable<Users>>GetAllAsync()
    {
        var data = await _context.Users.ToListAsync();
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

    public async Task<Users>GetByIdAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
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
