using CourtBookingApp.Models;
using CourtBookingApp.Data;
using Microsoft.EntityFrameworkCore;
using CourtBookingApp.Services.Courts;
using CourtBookingApp.DTO_s.Court;

namespace CourtBookingApp.Services.Courts;


public class CourtServices : ICourtService
{
    private readonly AppDbContext _context;

    public CourtServices(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Court> CreateCourtAsync(CreateCourtDto dto)
    {
        var court = new Court
        {
            Name = dto.Name,
            Type = dto.Type,
            HasRoof = dto.HasRoof,
            PricePerHour = dto.PricePerHour,
        };

        _context.Courts.Add(court);
        await _context.SaveChangesAsync();
        return court;
    }
    public async Task<Court> UpdateAsync(int id, UpdateCourtDto dto)
    {
        var court = await _context.Courts.FindAsync(id);
        
        court.Name = dto.Name;
        court.Type = dto.Type;
        court.HasRoof = dto.HasRoof;
        court.PricePerHour = dto.PricePerHour;

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
