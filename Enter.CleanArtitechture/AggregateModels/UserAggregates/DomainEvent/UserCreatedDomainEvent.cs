using ECA.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Domain.AggregateModels.UserAggregates.DomainEvent
{
    public class UserCreatedDomainEvent : IDomainEvent
    {
        
        public User User { get; set; }

        public UserCreatedDomainEvent(User user)
        {
            this.User = user ?? throw new ArgumentNullException(nameof(user));
        }
    }
}
