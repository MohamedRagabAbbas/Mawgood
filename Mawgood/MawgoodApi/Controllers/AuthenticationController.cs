using Mawgood.Core.DTO.Request;
using Mawgood.EF.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MawgoodApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService _authenticationService;
        public AuthenticationController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [Route("login/{email}/{password}")]
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var response = await _authenticationService.Authenticate(email,password);
            return Ok(response);
        }
        [Route("register-jobseeker")]
        [HttpPost]
        public async Task<IActionResult> RegisterJobSeeker([FromBody] JobSeekerRegistrationRequest request)
        {
            var response = await _authenticationService.RegisterJobSeeker(request);
            return Ok(response);
        }
        [Route("register-employer")]
        [HttpPost]
        public async Task<IActionResult> RegisterEmployer([FromBody] EmployerRegistrationRequest request)
        {
            var response = await _authenticationService.RegisterEmployer(request);
            return Ok(response);
        }
    }
}
