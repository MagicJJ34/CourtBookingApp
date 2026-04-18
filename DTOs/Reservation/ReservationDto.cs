using CourtBookingApp.Models;

namespace CourtBookingApp.DTOs.Reservation
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourtId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ReservationStatus Status { get; set; }
    }
}