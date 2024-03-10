using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Models.DTO;
using NZWalks.Repositories;
using System.Text;

namespace NZWalks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var identityUser = new IdentityUser()
            {
                UserName = registerRequestDTO.Email,
                Email = registerRequestDTO.Email
            };

            var result = await userManager.CreateAsync(identityUser, registerRequestDTO.Password);

            if (result.Succeeded)
            {
                if (registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
                {
                    result = await userManager.AddToRolesAsync(identityUser, registerRequestDTO.Roles);

                    if (result.Succeeded)
                    {
                        return Ok();
                    }
                }
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var user = await userManager.FindByEmailAsync(loginDTO.Email);

            if (user != null && await userManager.CheckPasswordAsync(user, loginDTO.Password))
            {
                var roles = await userManager.GetRolesAsync(user);

                if (roles != null)
                {
                    var token = tokenRepository.CreateJWT(user, [.. roles]);
                    
                    var loginResponseDTO = new LoginResponseDTO()
                    {
                        Token = token
                    };

                    return Ok(loginResponseDTO);
                }
            }

            return Unauthorized();
        }
    }
}
