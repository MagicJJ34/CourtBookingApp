using CourtBookingApp.Models;
using CourtBookingApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourtBookingApp.Services;

public class ReservationService : IReservationService
{
    private readonly AppDbContext _context;
    public ReservationService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Reservation> CreateReservationAsync(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();
        return reservation;
    }

    public async Task<List<Reservation>> GetAllAsync()

    {
        return await _context.Reservations.ToListAsync();
    }

    public async Task<Reservation?> GetByIdAsync(int id)
    {
        return await _context.Reservations.FindAsync(id);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var reservation = await _context.Reservations.FindAsync(id);
        if (reservation == null) return false;

        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();
        return true;    

    }
}