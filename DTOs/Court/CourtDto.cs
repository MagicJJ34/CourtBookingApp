namespace CourtBookingApp.DTO_s.Court
{
    public class CourtDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool HasRoof { get; set; }
        public int PricePerHour { get; set; }
    }
}
