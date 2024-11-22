using CommerceApp.Application.Features.Auth.Commands.Login;
using CommerceApp.Application.Features.Auth.Commands.RefreshToken;
using CommerceApp.Application.Features.Auth.Commands.RegisterCommand;
using CommerceApp.Application.Features.Auth.Commands.Revoke;
using CommerceApp.Application.Features.Auth.Commands.RevokeAll;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommerceApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
           var result =   await mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Revoke(RevokeCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RevokeAll()
        {
            await mediator.Send(new RevokeAllCommandRequest());
            return Ok();
        }
    }
}
