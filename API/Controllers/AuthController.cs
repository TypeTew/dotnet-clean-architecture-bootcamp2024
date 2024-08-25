using Application.Features.Register.Commands.CreateAccount;
using Application.Models.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;
        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterRequestDto request)
        {
            var register = await mediator.Send(new CreateAccountCommand { 
                RegisterModel  = request 
            });
            return Ok();
        }
    }
}
