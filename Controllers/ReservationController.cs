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
            var result = new ReservationDto
            {
                Id = createdReservation.Id,
                UserId = createdReservation.UserId,
                CourtId = createdReservation.CourtId,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                Status = createdReservation.Status,
            };
            return Ok(result);
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Reservation>>> GetAll()
        {
            var reservations = await _reservationService.GetAllAsync();
            foreach (var r in reservations)
            {
                if (r.EndTime < DateTime.Now && r.Status == ReservationStatus.Active)
                {
                    {
                        r.Status = ReservationStatus.Completed;
                    }
                }
            }
            return Ok(reservations);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Reservation>> GetById(int id)
        
        {
            var reservation = await _reservationService.GetByIdAsync(id);
            
            if (reservation == null) 
                return NotFound();

            if (reservation.EndTime < DateTime.Now &&
                reservation.Status == ReservationStatus.Active)
            {
                reservation.Status = ReservationStatus.Completed;
            }
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