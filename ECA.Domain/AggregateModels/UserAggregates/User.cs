using ECA.Domain.AggregateModels.UserAggregates.DomainEvent;
using ECA.Domain.Services;
using Optimum.SharedKernel.DomainDrivenDesign;

namespace ECA.Domain.AggregateModels.UserAggregates;

public class User : EntityBase<Guid>, IAggregateRoot
{

    private readonly Encryptor _encryptor;
    protected User()
    {
        _encryptor = new Encryptor();
    }

    public User(string username, string password,string firstName,string lastName, UserAddress address, UserStatus status)
    {
        _encryptor = new Encryptor();
        
        Username = username ?? throw new ArgumentNullException(nameof(username));
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        Address = address ?? throw new ArgumentNullException(nameof(address));
        Status = status ?? throw new ArgumentNullException(nameof(status));
        Password = _encryptor.Encrypt(password) ?? throw new ArgumentNullException(nameof(password));
        RefreshToken = _encryptor.Generate();
        RegisterDomainEvent(new UserCreatedDomainEvent(this));
    }

    public string Username { get; private set; }
    public string Password { get; private set; }
    public string RefreshToken { get; private set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserStatus Status { get; private set; }
    public UserAddress Address { get; private set; }

    public void SetUserName(string username)
    {
        Username = username;
        RegisterDomainEvent(new UserUsernameUpdatedDomainEvent(this));
    }

    public void SetPassword(string password)
    {
        Password = _encryptor.Encrypt(password);
    }
    
    public bool ComparePassword(string password)
    {
        return _encryptor.Validate(Password, password);
    }

    public void SetStatus(UserStatus status)
    {
        Status = status;
        RegisterDomainEvent(new UserStatusUpdatedDomainEvent(this));
    }
    
    public void NewRefreshToken()
    {
        RefreshToken = _encryptor.Generate();
        RegisterDomainEvent(new UserStatusUpdatedDomainEvent(this));
    }

    public void SetAddress(UserAddress address)
    {
        Address = address ?? throw new ArgumentNullException(nameof(address));
        RegisterDomainEvent(new UserUsernameUpdatedDomainEvent(this));
    }
}