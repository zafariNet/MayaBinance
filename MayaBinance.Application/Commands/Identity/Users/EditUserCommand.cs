using CSharpFunctionalExtensions;
using MediatR;

namespace MayaBinance.Application.Commands.Identity.Users
{
    public class EditUserCommand: IRequest<Result>
    {
        public EditUserCommand(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }
    }
}
