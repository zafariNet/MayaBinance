using FluentValidation;
using MayaBinance.Application.Dtos.Identity;

namespace MayaBinance.Application.Validations.Identity.Users
{
    public class CreateUserCommandValidator:AbstractValidator<CreateUserDto>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name must be insert !");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name must be insert !");
            RuleFor(x => x.EmailOrUserName).NotEmpty().WithMessage("Email or UserName must be insert !");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password name must be insert !");
        }
    }
}
