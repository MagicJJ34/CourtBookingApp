using CourtBookingApp.Models;
using CourtBookingApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourtBookingApp.DTOs.Reservation;
using System.Xml;

namespace CourtBookingApp.Services;

public class ReservationService : IReservationService
{
    private readonly AppDbContext _context;
    public ReservationService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<ReservationDto> CreateAsync(CreateReservationDto dto)
    {
        var court = await _context.Courts.FindAsync(dto.CourtId);
        if (court == null)
            throw new Exception("Court not found");

        var user = await _context.Users.FindAsync(dto.UserId);
        if (user == null)
            throw new Exception("User not found");

        var reservation = new Reservation
        {
            UserId = dto.UserId,
            CourtId = dto.CourtId,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime,
        };
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();

        return new ReservationDto
        {
            Id = reservation.Id,
            UserId = reservation.UserId,
            CourtId = reservation.CourtId,
            StartTime = reservation.StartTime,
            EndTime = reservation.EndTime
        };
    }

    public async Task<List<Reservation>> GetAllAsync()
    {
        var reservations = await _context.Reservations.ToListAsync();
        foreach (var r in reservations)
        {
            if (r.EndTime < DateTime.Now && r.Status == ReservationStatus.Active)
            {
                {
                    r.Status = ReservationStatus.Completed;
                }
            }
        }
        await _context.SaveChangesAsync();
        return reservations;
    }

    public async Task<Reservation?> GetByIdAsync(int id)
    {
        var reservation = await _context.Reservations.FindAsync(id);

        if (reservation.EndTime < DateTime.Now &&
            reservation.Status == ReservationStatus.Active)
        {
            reservation.Status = ReservationStatus.Completed;
        }
        await _context.SaveChangesAsync();
        return reservation;
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