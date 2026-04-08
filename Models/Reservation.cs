using Microsoft.AspNetCore.SignalR;

namespace CourtBookingApp.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourtId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public enum Status 
        {
            Active,
            Cancelled,
            Completed
        }
        public DateTime CreatedAt { get; set; }

        public User? User { get; set; }
        public Court? Court { get; set; }
    }
}
