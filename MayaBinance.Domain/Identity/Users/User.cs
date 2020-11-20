using System;
using MayaBinance.Domain.Identity.Users.DomainEvents;
using MayaBinance.Domain.SeedWork;
using MayaBinance.Domain.ValueObjects;

namespace MayaBinance.Domain.Identity.Users
{
    public class User : AggregateRoot<Guid, User>
    {
        protected User()
        {
        }
        public User(string firstName, string lastname, string emailOrUserName,
            string password, Address address)
        {
            FirstName = firstName;
            LastName = lastname;
            EmailOrUserName = emailOrUserName;
            Password = password;
            Address = address;
            UserCreated();
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string EmailOrUserName { get; }
        public string Password { get; }
        public Address Address { get;  }

        private void UserCreated()
        {
            AddEvent(new UserCreatedEvent(FirstName,LastName, EmailOrUserName,Password,Address));
        }

    }
}
