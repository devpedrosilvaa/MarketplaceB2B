using FluentValidation;
using MarketplaceB2B.API.Extensions;
using MarketplaceB2B.Application.Dtos;
using MarketplaceB2B.Application.Helpers;
using MarketplaceB2B.Application.Interfaces;
using MarketplaceB2B.Domain.Entities;
using MarketplaceB2B.Domain.Enums;
using MarketplaceB2B.Infrastructure.Identities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceB2B.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase {

        private readonly IValidator<ProviderRegisterDTO> _registerValidator;
        private readonly UserManager<AppUser> _userManager;
        private readonly IProviderService _providerService;
        public ProviderController(IValidator<ProviderRegisterDTO> registerValidator, UserManager<AppUser> userManager,
                                    IProviderService providerService) {
            _registerValidator = registerValidator;
            _userManager = userManager;
            _providerService = providerService;
        }

        [HttpPost("register")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> SaveProvider([FromBody] ProviderRegisterDTO registerDTO) {
            try {
                var validationResult = _registerValidator.Validate(registerDTO);
                if (!validationResult.IsValid) {
                    var problemDetails = new HttpValidationProblemDetails(validationResult.ToDictionary()) {
                        Status = StatusCodes.Status400BadRequest,
                        Title = "Validation failed",
                        Detail = "One or more validation erros occurred",
                        Instance = Request.Path
                    };
                    return BadRequest(problemDetails);
                }

                var username = User.GetUsername().ToLower();
                var appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName!.ToLower().Equals(username));
                if (appUser == null)
                    return NotFound($"User with UserName: {username} not found.");
                if (!appUser.TypeUser.Equals(TypeUser.PROVIDER))
                    return BadRequest("Logged User not type PROVIDER");

                Provider provider = new Provider() {
                    CPF = registerDTO.CPF,
                    Status = StatusProvider.ACTIVE,
                    AppUserId = appUser.Id,
                    Description = registerDTO.Description
                };

                var message = await _providerService.SaveProvider(provider);
                if (message != Helper.DefaultMessage.INSERT.ToString()) 
                    return BadRequest(message);
                return Ok(message);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
