using CourtBookingApp.Models;
using CourtBookingApp.Data;
using Microsoft.EntityFrameworkCore;
using CourtBookingApp.Services.Courts;

namespace CourtBookingApp.Services.Courts;


public class CourtServices : ICourtService
{
    private readonly AppDbContext _context;

    public CourtServices(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Court> CreateCourtAsync(Court court)
    {
        _context.Courts.Add(court);
        await _context.SaveChangesAsync();
        return court;
    }
    public async Task<Court> UpdateAsync(int id, Court updatedCourt)
    {
        var court = await _context.Courts.FindAsync(id);

        court.Name = updatedCourt.Name;
        court.Type = updatedCourt.Type;
        court.HasRoof = updatedCourt.HasRoof;
        court.PricePerHour = updatedCourt.PricePerHour;

        await _context.SaveChangesAsync();
        return court;
    }
    
    public async Task<IEnumerable<Court>>GetAllAsync()
    {
        var data = await _context.Courts.ToListAsync();
        return data;
    }

    public async Task<Court> GetByIdAsync(int id)
    {
        var court = await _context.Courts.FindAsync(id);
        return court;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var court = await _context.Courts.FindAsync(id);
        _context.Courts.Remove(court);
        await _context.SaveChangesAsync();
        return true;
    }
}
