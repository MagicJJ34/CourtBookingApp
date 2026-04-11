using CourtBookingApp.Models;
using CourtBookingApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourtBookingApp.Services;
using CourtBookingApp.DTOs.User;
using CourtBookingApp.DTO_s.User;

namespace CourtBookingApp.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase

    {
        private readonly IUserService _userservice;

        public UserController(IUserService userService)
        {
            _userservice = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(CreateUserDto dto)
        {
            var user = new Users
            {
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Role = "User"
            };

            var createdUser = await _userservice.CreateUserAsync(user);

            var result = new UserDto
            {
                Id = createdUser.Id,
                Name = createdUser.Name,
                Email = createdUser.Email,
                PhoneNumber = createdUser.PhoneNumber,
                Role = "User"
            };
            return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult<Users>> Update(int id, Users updatedUser)
        {
            var user = await _userservice.UpdateAsync(id, updatedUser);
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetAll()
        {
            var users = await _userservice.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetById(int id)
        {
            var user = await _userservice.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userservice.DeleteAsync(id);
            return NoContent();
        }
    }
}
