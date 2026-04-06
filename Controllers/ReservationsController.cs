using CourtBookingApp.Models;
using CourtBookingApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace CourtBookingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _service;

        public ReservationsController(IReservationService service)

        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<Reservation>> Create([FromBody]Reservation reservation)
        {
            var createdReservation = await _service.CreateAsync(reservation);
            return CreatedAtAction(nameof(Create), new { createdReservation.Id }, createdReservation);
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Reservation>>> GetAll()
        {
            var reservations = await _service.GetAllAsync();
            return Ok(reservations);
        }

    }

}