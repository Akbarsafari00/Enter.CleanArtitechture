using ECA.Domain.AggregateModels.UserAggregates.DomainEvent;
using ECA.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Domain.AggregateModels.UserAggregates
{
    public class User : AggregateRoot<Guid>
    {
        public string UserName { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public UserStatus Status { get; private set; } = default!;
        public UserAddress Address { get; private set; } = default!;

        public User(string username , string password , UserAddress address , UserStatus status)
        {
            this.UserName = username ?? throw new ArgumentNullException(nameof(username));
            this.Password = password ?? throw new ArgumentNullException(nameof(password));
            this.Address = address ?? throw new ArgumentNullException(nameof(address));
            this.Status = status ?? throw new ArgumentNullException(nameof(status));

            AddDomainEvent(new UserCreatedDomainEvent(this));
        }

        public void SetUserName(string username) => UserName = username;
        public void SetPassowrd(string password) => Password = password;
        public void SetStatus(UserStatus status) => Status = status;
        public void SetAddress(UserAddress address)
        {
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }

    }
}
