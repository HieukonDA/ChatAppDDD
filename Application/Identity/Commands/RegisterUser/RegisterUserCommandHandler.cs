using Application.Common;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Identity.Abtractions;
using Domain.IdentityContext.UsersAggregates;
using Domain.IdentityContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : CommandHandlerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHash _passwordHash;

        public RegisterUserCommandHandler(IUserRepository userRepository,
            IPasswordHash passwordHash,
            IEventBus eventBus, IUnitOfWork unitOfWork) : base(eventBus, unitOfWork)
        {
            _userRepository = userRepository;
            _passwordHash = passwordHash;
        }

        public async Task<Guid> Handle(RegisterUserCommand command)
        {
            //1. validate data
            var validator = new RegisterUserCommandValidator();
            var validationResult = await validator.ValidateAsync(command);
            if(!validationResult.IsValid)
            {
                throw new InvalidCredentialsException();
            }

            //2. check email uniqueness
            var email = Email.Create(command.Email);
            var existingUser = await _userRepository.IsEmailExistsAsync(email);
            if (existingUser)
            {
                throw new InvalidCredentialsException();
            }

            //3. create user
            var user = User.Register(
                UserId.New(),
                email,
                UserName.Create(command.UserName),
                PasswordHash.Create(_passwordHash.Hash(command.Password))
            );

            //4. save user
            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return user.Id.Id;
        }
    }
}
