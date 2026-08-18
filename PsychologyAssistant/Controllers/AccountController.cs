using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsychologyAssistant.DTOs.Account;
using PsychologyAssistant.Interfaces;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerUserDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = new User
                {
                    UserName = registerUserDto.Username,
                    Email = registerUserDto.Email,
                    FirstName = registerUserDto.FirstName,
                    LastName = registerUserDto.LastName,
                    BirthDate = registerUserDto.BirthDate,
                    Specialization = registerUserDto.Specialization,
                    PhoneNumber = registerUserDto.PhoneNumber,
                    Gender = registerUserDto.Gender,
                    LicenceNumber = registerUserDto.LicenceNumber,
                    WorkingHoursStart = registerUserDto.WorkingHoursStart,
                    WorkingHoursEnd = registerUserDto.WorkingHoursEnd,
                    OfficeAddress = registerUserDto.OfficeAddress,
                };

                var createdUser = await _userManager.CreateAsync(user, registerUserDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new NewUserDto
                            {
                                Username = user.UserName,
                                Email = user.Email,
                                Token = _tokenService.CreateToken(user)
                            }
                        );
                    }
                    else
                    {
                        return BadRequest(roleResult.Errors);
                    }
                }
                else
                {
                    return BadRequest(createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginUserDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginUserDto.Username);
                if (user == null)
                {
                    return Unauthorized("Invalid username.");
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, loginUserDto.Password, false);
                if (!result.Succeeded)
                {
                    return Unauthorized("Username not found and/or passoword incorrect.");
                }

                return Ok(
                    new NewUserDto
                    {
                        Username = user.UserName,
                        Email = user.Email,
                        Token = _tokenService.CreateToken(user)
                    }
                );
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }
    }
}
