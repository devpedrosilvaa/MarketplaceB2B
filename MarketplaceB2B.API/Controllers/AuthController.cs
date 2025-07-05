using MarketplaceB2B.Application.Interfaces;
using MarketplaceB2B.Application.Dtos;
using MarketplaceB2B.Infrastructure.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceB2B.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService) {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userRegisterDTO) {
            try {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = new AppUser {
                    UserName = userRegisterDTO.UserName,
                    Email = userRegisterDTO.Email,
                    CreatedAt = DateTime.UtcNow,
                };

                var result = await _userManager.CreateAsync(user, userRegisterDTO.Password);
                if (result.Succeeded) {
                    var resultRole = await _userManager.AddToRoleAsync(user, "User");
                    if (!resultRole.Succeeded)
                        return Ok(new { Message = "User registered successfully" });
                    else
                        return StatusCode(500, "ROLE" + resultRole.Errors);
                }
                else
                    return StatusCode(500, "USER" + result.Errors);
            }
            catch (Exception ex) {
                return StatusCode(500, "EX" + ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO) {
            try {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName.ToLower() == userLoginDTO.UserName.ToLower());
                if (user == null)
                    return Unauthorized("Username or password is incorrect");

                var result = await _signInManager.CheckPasswordSignInAsync(user, userLoginDTO.Password, false);
                if (result.Succeeded) {
                    user.LastLogin = DateTime.UtcNow;
                    await _userManager.UpdateAsync(user);
                    var token = await _tokenService.GenerateToken(user.UserName);
                    return Ok(new { Token = token });
                }
                else
                    return Unauthorized("Username or password is incorrect");
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
