using CourtBookingApp.DTO_s.Court;
using CourtBookingApp.DTO_s.User;
using CourtBookingApp.Models;

namespace CourtBookingApp.Services;

    public interface IUserService
    {
        Task<Users> CreateUserAsync(CreateUserDto dto);
        Task<IEnumerable<Users>> GetAllAsync();
        Task<Users> UpdateAsync(int id, UpdateUserDto dto);
        Task<Users> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
