using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingWebsite.Application.Contracts.Identity;
using TrainingWebsite.Application.Models.Identity;

namespace TrainingWebsite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authenticationService;

        public AuthController(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            var user = await _authenticationService.Login(request);
            return Ok(user);
        }
        
        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            var user = await _authenticationService.Register(request);
            return Ok(user);
        }
    }
}
