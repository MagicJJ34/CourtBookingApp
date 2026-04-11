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
            var createdUser = await _userservice.CreateUserAsync(dto);

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
        public async Task<ActionResult<UserDto>> Update(int id, UpdateUserDto dto)
        {
            var user = await _userservice.UpdateAsync(id, dto);
            var result = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
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
