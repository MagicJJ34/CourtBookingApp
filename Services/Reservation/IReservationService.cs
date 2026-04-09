using CourtBookingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourtBookingApp.Services;

public interface IReservationService
{
    Task<Reservation> CreateReservationAsync(Reservation reservation);
    Task<List<Reservation>> GetAllAsync();
    Task<Reservation?> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
}