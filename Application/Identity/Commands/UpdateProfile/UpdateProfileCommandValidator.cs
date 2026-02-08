using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity.Commands.UpdateProfile
{
    public class UpdateProfileCommandValidator : AbstractValidator<UpdateProfileCommand>
    {
        public UpdateProfileCommandValidator() 
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.UserName)
                .NotEmpty()
                .MinimumLength(3);

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(11);
            RuleFor(x => x.AvatarUrl)
                .NotEmpty()
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                .WithMessage("AvatarUrl must be a valid URL.");
        }
    }
}
