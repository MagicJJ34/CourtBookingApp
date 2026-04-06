using CourtBookingApp.Models;
using CourtBookingApp.Data;
using Microsoft.EntityFrameworkCore;

namespace CourtBookingApp.Services
{
    public class ReservationService : IReservationService
    {
        private readonly  AppDbContext _context;
        public ReservationService (AppDbContext context)
        {
            _context = context;
        }
        public async Task<Reservation> CreateAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task<List<Reservation>> GetAllAsync()
        
        {
            return await _context.Reservations.ToListAsync();
        }
    }
}
