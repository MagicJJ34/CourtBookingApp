using Microsoft.AspNetCore.Mvc;
using CourtBookingApp.Models;
using System.Security.AccessControl;
using CourtBookingApp.Data;

namespace CourtBookingApp.Services.Courts
{
    public interface ICourtService
    {
        Task<Court> CreateCourtAsync(Court court);
        Task<IEnumerable<Court>> GetAllAsync();
        Task<Court> UpdateAsync(int id, Court updatedCourt);
        Task<Court> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
