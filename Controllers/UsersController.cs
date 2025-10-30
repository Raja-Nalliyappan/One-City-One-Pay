using Microsoft.AspNetCore.Mvc;
using One_City_One_Pay.Data;
using One_City_One_Pay.Moduls;
using BCrypt.Net;

namespace One_City_One_Pay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _userRepo;

        public UsersController(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost]
        public IActionResult Create([FromBody] LoginUsers users)
        {
            if (users == null)
                return BadRequest("User data is null.");

            try
            {
                var existingUser = _userRepo.GetUserByEmailID(users.Email);
                if (existingUser != null)
                {
                    return Conflict("User with this email already exists.");
                }
                users.Password = BCrypt.Net.BCrypt.HashPassword(users.Password);
                _userRepo.AddUser(users);
                return Ok("User Added Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] string email, [FromQuery] string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return BadRequest(new { message = "Email and Password are required" });

            try
            {
                var existingUser = _userRepo.GetUserByEmailID(email); // Fetch user from DB by email

                if (existingUser == null) return NotFound(new { message = "User not found" });

                // Verify the entered password against the stored hash
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, existingUser.Password);

                if (!isPasswordValid)
                {
                    return Unauthorized(new { message = "Invalid password" });
                }

                return Ok(new { message = "Login successful - Welcome to Our Page", user = existingUser });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });
            }
        }


        [HttpGet("GetRegisterUserList")]

        public IActionResult GetRegisterUserList()
        {
            var users = _userRepo.GetAllUsers();
            return Ok(users);
        }


        [HttpPut("{id:int}")]
        public IActionResult Update(LoginUsers users)
        {
            _userRepo.UpdateUser(users);
            return Ok("User Updated Successfully");
        }

        [HttpPost("reset-password")]
        public IActionResult ResetPassword([FromBody] ResetPasswordRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.NewPassword))
                return BadRequest("Email and new password are required.");

            try
            {
                var existingUser = _userRepo.GetUserByEmailID(request.Email);
                if (existingUser == null)
                {
                    return NotFound("User with this email not found.");
                }

                // Hash the new password and update the user record
                existingUser.Password = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
                _userRepo.UpdateUser(existingUser);

                return Ok("Password reset successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });
            }
        }
    }
}
