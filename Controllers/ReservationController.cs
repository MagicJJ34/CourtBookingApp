using CourtBookingApp.DTOs.Reservation;
using CourtBookingApp.Models;
using CourtBookingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourtBookingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)

        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateReservationDto dto)
        {
            var createdReservation = await _reservationService.CreateAsync(dto);
            return Ok(createdReservation);
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Reservation>>> GetAll()
        {
            var reservations = await _reservationService.GetAllAsync();
            return Ok(reservations);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Reservation>> GetById(int id)
        
        {
            var reservation = await _reservationService.GetByIdAsync(id);
            if (reservation == null) 
                return NotFound();

            return Ok(reservation);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _reservationService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

    }

}