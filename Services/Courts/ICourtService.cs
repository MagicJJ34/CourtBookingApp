using Microsoft.AspNetCore.Mvc;
using CourtBookingApp.Models;
using System.Security.AccessControl;
using CourtBookingApp.Data;
using CourtBookingApp.DTO_s.Court;

namespace CourtBookingApp.Services.Courts
{
    public interface ICourtService
    {
        Task<Court> CreateCourtAsync(CreateCourtDto dto);
        Task<IEnumerable<Court>> GetAllAsync();
        Task<Court> UpdateAsync(int id, UpdateCourtDto dto);
        Task<Court> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
