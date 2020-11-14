using System;
using MayaBinance.Domain.ValueObjects;

namespace MayaBinance.Application.Dtos.Identity
{
    public class CreateUserDto
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailOrUserName { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
    }

    public class SimpleUserViewModel:BaseSimpleViewModel<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailOrUserName { get; set; }
        public string FullName { get; set; }

    }
}
