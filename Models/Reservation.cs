using Microsoft.AspNetCore.SignalR;
namespace CourtBookingApp.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Users? User { get; set; }
        public int CourtId { get; set; }
        public Court? Court { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ReservationStatus Status { get; set; } = ReservationStatus.Active;
        public DateTime CreatedAt { get; set; }
    }
}
