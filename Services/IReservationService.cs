using CourtBookingApp.Models;

namespace CourtBookingApp.Services
{
    public interface IReservationService
    {
        Task<Reservation> CreateReservationAsync(Reservation reservation);
        Task<List<Reservation>> GetAllAsync();
    }
}
