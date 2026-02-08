using Application.Common;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Identity.Abtractions;
using Application.Identity.DTOs;
using Domain.IdentityContext.UsersAggregates;
using Domain.IdentityContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity.Commands.LoginUser
{
    public class LoginUserCommandHandler : CommandHandlerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHash _passwordHash;
        private readonly ITokenGenerator _tokenGenerator;
        public LoginUserCommandHandler(IUserRepository userRepository,
            IPasswordHash passwordHash,
            ITokenGenerator tokenGenerator,
            IEventBus eventBus, IUnitOfWork unitOfWork) : base(eventBus, unitOfWork)
        {
            _userRepository = userRepository;
            _passwordHash = passwordHash;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<LoginResponseDto> Handle(LoginUserCommand command)
        {
            //1. validate data
            var validator  = new LoginUserCommandValidator();
            var validatorResult = await validator.ValidateAsync(command);
            if(!validatorResult.IsValid)
            {
                throw new InvalidCredentialsException();
            }

            //2. get email value object
            var email = Email.Create(command.Email);

            //3. get user by email and password
            var user = await _userRepository.GetByEmailAsync(email);
            if(user == null ) throw new InvalidCredentialsException();

            if (!_passwordHash.Verify(user.PasswordHash.ToString(), command.Password))
            {
                throw new InvalidCredentialsException();
            }

            //4. generate token
            var accessToken = _tokenGenerator.GenerateToken(user.Id.ToString(), user.UserName.ToString(), user.Email.ToString());
            var refreshToken = _tokenGenerator.GenerateRefreshToken();

            //5. return token
            var AuthResult = new LoginResponseDto
            {
                UserDto = new UserDto
                {
                    UserId = user.Id.Id,
                    UserName = user.UserName.ToString(),
                    Email = user.Email.ToString(),
                    PhoneNumber = user.PhoneNumber?.ToString(),
                },
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresAt = DateTime.UtcNow.AddMinutes(60)
            };

            return AuthResult;
        }
    }
}
