using System.Collections.Generic;
using MayaBinance.Domain.SeedWork;

namespace MayaBinance.Domain.ValueObjects
{
    public class Address:ValueObject
    {
        public string Street { get;  }
        public string City { get; }
        public string Country { get; }
        public string ZipCode { get; }
        public Address() { }
        public Address(string street, string city, string country, string
            zipcode)
        {
            Street = street;
            City = city;
            Country = country;
            ZipCode = zipcode;
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return City;
            yield return Country;
            yield return ZipCode;
        }
    }
}
