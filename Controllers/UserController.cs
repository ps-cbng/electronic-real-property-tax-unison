using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ElectronicRealPropertyTaxUnisan.Models;
using ElectronicRealPropertyTaxUnisan.Services;
using ElectronicRealPropertyTaxUnisan.Services.Interfaces;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<User>> GetUser(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return BadRequest("Email cannot be empty");
            }

            try
            {
                var user = await _userService.GetAsync(email);
                if (user == null)
                {
                    return NotFound($"User with email {email} not found");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while retrieving the user");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            try
            {
                return Ok(await _userService.GetAllAsync());
            }
            catch (System.Exception)
            {
                return BadRequest();
                throw;
            }
        }

    }
}
