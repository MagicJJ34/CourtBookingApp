using System.Xml.Linq;
using CourtBookingApp.DTO_s.Court;
using CourtBookingApp.Models;
using CourtBookingApp.Services;
using CourtBookingApp.Services.Courts;
using Microsoft.AspNetCore.Mvc;

namespace CourtBookingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourtController : ControllerBase
    {
        private readonly ICourtService _courtService;

        public CourtController(ICourtService courtService)
        {
            _courtService = courtService;
        }

        [HttpPost]

        public async Task<ActionResult<CourtDto>> CreateCourt(CreateCourtDto dto)
        {
            var createdCourt = await _courtService.CreateCourtAsync(dto);

            var result = new CourtDto
            {
                Id = createdCourt.Id,
                Name = createdCourt.Name,
                Type = createdCourt.Type,
                HasRoof = createdCourt.HasRoof,
                PricePerHour = createdCourt.PricePerHour
            };

            return CreatedAtAction("GetById", new { id = createdCourt.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult<CourtDto>> Update(int id, UpdateCourtDto dto)
        {
            var court = await _courtService.UpdateAsync(id, dto);

            var result = new CourtDto
            {
                Id = court.Id,
                Name = court.Name,
                Type = court.Type,
                HasRoof = court.HasRoof,
                PricePerHour = court.PricePerHour
            };
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Court>>> GetAll()
        {
            var courts = await _courtService.GetAllAsync();
            return Ok(courts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Court>> GetById(int id)
        {
            var court = await _courtService.GetByIdAsync(id);
            return Ok(court);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var court = await _courtService.DeleteAsync(id);
            return Ok(court);
        }

    }
}
