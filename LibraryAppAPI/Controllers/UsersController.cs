using FluentValidation;
using LibraryAppAPI.Dto;
using LibraryAppAPI.Services;
using LibraryAppDomain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryAppAPI.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IValidator<RegisterDto> _registerValidator;
        private readonly IConfiguration _config;

        public UsersController(IUserService userService, IValidator<RegisterDto> registerValidator, IConfiguration config)
        {
            _userService = userService;
            _registerValidator = registerValidator ?? throw new ArgumentNullException(nameof(registerValidator));
            _config = config;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> Index()
        {
            var uaerDto = await _userService.GetAllUserAsync();
            return Ok(uaerDto);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var movieDto = await _userService.GetUserAsync(userId);
            return Ok(movieDto);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int userId)
         {
            await _userService.DeleteUserAsync(userId);
            return Ok();
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            await _userService.RegisterUserAsync(registerDto);
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login( LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user=await _userService.LoginUserAsync(loginDto);
           

            if (user == null)
                return BadRequest("Username or password incorrects.");

            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                return BadRequest("Username or password incorrect.");

            string token = GenerateToken(user);

            return Ok(new {token});
        }
        private string GenerateToken(User user)
        {
            List<Claim> authclaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Secret").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var expiretime = DateTime.Now.AddHours(1);
            var token = new JwtSecurityToken(
                claims: authclaims, 
                expires: expiretime, 
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

           

            return jwt;
        }
    }

}
