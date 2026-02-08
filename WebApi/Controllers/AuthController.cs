using Application.Identity.Commands.LoginUser;
using Application.Identity.Commands.RegisterUser;
using Application.Identity.DTOs;
using Contracts.Identity;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly RegisterUserCommandHandler _registerHandler;
        private readonly LoginUserCommandHandler _loginHandler;
        public AuthController(RegisterUserCommandHandler registerHandler,
            LoginUserCommandHandler loginHandler    )
        {
            _registerHandler = registerHandler;
            _loginHandler = loginHandler;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var command = new RegisterUserCommand(
                request.Email,
                request.UserName,
                request.Password
            );

            var userId = await _registerHandler.Handle(command);
            return Created("", new { UserId = userId });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var command = new LoginUserCommand(
                request.Email,
                request.Password
            );

            var authResponse = await _loginHandler.Handle(command);
            return Ok(authResponse);
        }
    }
}
