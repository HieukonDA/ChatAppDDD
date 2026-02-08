using Application.Common;
using Application.Common.Interfaces;
using Domain.IdentityContext.UsersAggregates;
using Domain.IdentityContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity.Commands.UpdateProfile
{
    public class UpdateProfileCommandHandler : CommandHandlerBase
    {
        private readonly IUserRepository _userRepository;
        public UpdateProfileCommandHandler(IUserRepository userRepository,IEventBus eventBus, IUnitOfWork unitOfWork) : base(eventBus, unitOfWork)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateProfileCommand command)
        {
            var email = Email.Create(command.Email);
            if(email == null)
            {
                throw new ArgumentException("Email is required.");
            }
            var user = await _userRepository.GetByEmailAsync(email);

            if (command.Email != null)
                user.ChangeEmail(Email.Create(command.Email));

            if (command.UserName != null)
                user.ChangeUsername(UserName.Create(command.UserName));

            if (command.PhoneNumber != null)
                user.ChangePhoneNumber(PhoneNumber.Create(command.PhoneNumber));

            if (command.AvatarUrl != null)
                user.ChangeAvatar(AvatarUrl.Create(command.AvatarUrl));

            await _unitOfWork.SaveChangesAsync();
        }

    }
}
