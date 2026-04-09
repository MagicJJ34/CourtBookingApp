namespace CourtBookingApp.DTOs.Reservation
{
    public class CreateReservationDto
    {
        public int UserId { get; set; }
        public int CourtId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}