using CourtBookingApp.Models;

namespace CourtBookingApp.Services
{
    public interface IReservationService
    {
        Task<Reservation> CreateAsync(Reservation reservation);
        Task<List<Reservation>> GetAllAsync();
    }
}
