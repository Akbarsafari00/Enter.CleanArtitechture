using Optimum.SharedKernel.DomainDrivenDesign;

namespace ECA.Domain.AggregateModels.UserAggregates;

public class UserAddress : ValueObject
{
    public UserAddress(string city, string postalCode, string address)
    {
        City = city ?? throw new ArgumentNullException(nameof(city));
        PostalCode = postalCode ?? throw new ArgumentNullException(nameof(postalCode));
        Address = address ?? throw new ArgumentNullException(nameof(address));
    }

    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Address { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return City;
        yield return PostalCode;
    }
}