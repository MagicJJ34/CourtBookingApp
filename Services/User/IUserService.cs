using CourtBookingApp.Models;

namespace CourtBookingApp.Services;

    public interface IUserService
    {
        Task<Users> CreateUserAsync(Users user);
        Task<IEnumerable<Users>> GetAllAsync();
        Task<Users> UpdateAsync(int id, Users updatedUser);
        Task<Users> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
