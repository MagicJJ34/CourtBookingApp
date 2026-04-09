using CourtBookingApp.Models;
using CourtBookingApp.DTOs.Reservation;

public static class ReservationMapping
{
    public static ReservationDto ToDto(this Reservation reservation)
    {
        return new ReservationDto
        {
            Id = reservation.Id,
            UserId = reservation.UserId,
            CourtId = reservation.CourtId,
            StartTime = reservation.StartTime,
            EndTime = reservation.EndTime
        };
    }

    public static Reservation ToEntity(this CreateReservationDto dto)
    {
        return new Reservation
        {
            UserId = dto.UserId,
            CourtId = dto.CourtId,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime
        };
    }
}