using CSharpFunctionalExtensions;
using MayaBinance.Domain.ValueObjects;
using MayaBinance.Shared.Extensions;
using MediatR;

namespace MayaBinance.Application.Commands.Identity.Users
{
    public class CreateUserCommand: IRequest<Result>
    {
        public CreateUserCommand(string firstName, string lastName, string emailOrUserName, string password, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailOrUserName = emailOrUserName;
            Password = password.Encrypt();
            Address = address;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string EmailOrUserName { get; }
        public string Password { get; }
        public Address Address { get; }
    }
}
