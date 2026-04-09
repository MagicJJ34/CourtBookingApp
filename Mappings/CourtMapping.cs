using CourtBookingApp.Models;
using CourtBookingApp.DTO_s.Court;

public static class CourtMapping
{
    public static CourtDto ToDto(this Court court)
    {
        return new CourtDto
        {
            Id = court.Id,
            Name = court.Name,
            Type = court.Type,
            HasRoof = court.HasRoof,
            PricePerHour = court.PricePerHour
        };
    }

    public static Court ToEntity(this CreateCourtDto dto)
    {
        return new Court
        {
            Name = dto.Name,
            Type = dto.Type,
            HasRoof = dto.HasRoof,
            PricePerHour = dto.PricePerHour
        };
    }
}