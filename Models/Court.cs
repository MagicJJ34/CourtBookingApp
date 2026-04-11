namespace CourtBookingApp.Models
{
    public class Court
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool HasRoof { get; set; }
        public int PricePerHour { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
