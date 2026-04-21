using CourtBookingApp.DTOs.Reservation;
using CourtBookingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourtBookingApp.Services;

public interface IReservationService
{
    Task<ReservationDto> CreateAsync(CreateReservationDto dto);
    Task<List<Reservation>> GetAllAsync();
    Task<Reservation?> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
    Task<bool> CancelledReservationAsync(int id);
}