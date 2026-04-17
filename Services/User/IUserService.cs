using CourtBookingApp.DTO_s.Court;
using CourtBookingApp.DTO_s.User;
using CourtBookingApp.Models;
using CourtBookingApp.DTOs.User;

namespace CourtBookingApp.Services;

    public interface IUserService
    {
        Task<Users> CreateUserAsync(CreateUserDto dto);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<Users> UpdateAsync(int id, UpdateUserDto dto);
        Task<UserDto> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
