namespace CourtBookingApp.DTO_s.Court
{
    public class UpdateCourtDto
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public bool HasRoof { get; set; }
        public int PricePerHour { get; set; }
    }
}
