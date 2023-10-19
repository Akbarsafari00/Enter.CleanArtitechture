using ECA.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Domain.AggregateModels.UserAggregates
{
    public class UserAddress : ValueObject
    {
        public string City { get; } = string.Empty;
        public string PostalCode { get; } = string.Empty;
        public string Address { get; } = string.Empty;

        public UserAddress(string city, string postalCode, string address)
        {
            City = city ?? throw new ArgumentNullException(nameof(city));
            PostalCode = postalCode ?? throw new ArgumentNullException(nameof(postalCode));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return City;
            yield return PostalCode;
        }

    }
}
