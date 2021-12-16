using BetScore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BetScore.WebAPI.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{email}", Name = nameof(GetUserByEmail))]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var response = await _userService.FindByEmail(email);
            if (response == null) return StatusCode(404,NotFound());
            return StatusCode(200, response);
        }
    }
}
