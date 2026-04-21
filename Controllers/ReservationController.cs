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
                StartTime = createdReservation.StartTime,
                EndTime = createdReservation.EndTime,
                Status = createdReservation.Status,
            };
            return Ok(result);
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<ReservationDto>>> GetAll()
        {
            var reservations = await _reservationService.GetAllAsync();
            var reservationDtos = new List<ReservationDto>();
            foreach (var reservation in reservations)
            {
                reservationDtos.Add(new ReservationDto
                {
                    Id = reservation.Id,
                    UserId = reservation.UserId,
                    CourtId = reservation.CourtId,
                    StartTime = reservation.StartTime,
                    EndTime = reservation.EndTime,
                    Status = reservation.Status,
                });
            }
            return Ok(reservationDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDto>> GetById(int id)
        {
            var reservation = await _reservationService.GetByIdAsync(id);
            var result = new ReservationDto
            {
                Id = reservation.Id,
                UserId = reservation.UserId,
                CourtId = reservation.CourtId,
                StartTime = reservation.StartTime,
                EndTime = reservation.EndTime,
                Status = reservation.Status,
            };
            return Ok(result);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> CancelledReservation(int id)
        {
            var reservation = await _reservationService.CancelledReservationAsync(id);

            return Ok(reservation);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _reservationService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return Ok(deleted);
        }

    }

}