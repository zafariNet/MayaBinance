using System;
using System.Collections.Generic;
using System.Text;
using MayaBinance.Domain.ValueObjects;
using MayaBinance.Shared.Extensions;
using MediatR;

namespace MayaBinance.Domain.Identity.Users.DomainEvents
{
    public class UserCreatedEvent:INotification
    {
        public UserCreatedEvent(string firstName, string lastName, 
            string emailOrUserName, string password, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailOrUserName = emailOrUserName;
            Address = address;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string EmailOrUserName { get; }
        public Address Address { get; }
    }
}
