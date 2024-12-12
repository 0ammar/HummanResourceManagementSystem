using HummanResourceManagementSystem.DTOs.Authantication.Request;
using HummanResourceManagementSystem.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HummanResourceManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthanticationService _authantication;

        public AuthController(IAuthanticationService authantication)
        {
            _authantication = authantication;
        }

        //Login
        [HttpPost]
        public async Task<IActionResult> Auth([FromBody] LoginDTO input)
        {
            try
            {
                var response = await _authantication.Login(input);
                return response.Equals("Authantication Failed") ? Unauthorized("Email Or Password Is Not Correct") : Ok(response);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
