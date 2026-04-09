using CourtBookingApp.Models;
using CourtBookingApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace CourtBookingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _service;

        public ReservationController(IReservationService service)

        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<Reservation>> CreateReservation([FromBody]Reservation reservation)
        {
            var createdReservation = await _service.CreateReservationAsync(reservation);
            return CreatedAtAction(nameof(CreateReservation), new { createdReservation.Id }, createdReservation);
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Reservation>>> GetAll()
        {
            var reservations = await _service.GetAllAsync();
            return Ok(reservations);
        }

    }

}