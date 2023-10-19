using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Domain.Core
{
    public class AggregateRoot<TId> : Entity<TId>
    {
        private List<IDomainEvent> _domainEvents;

        public List<IDomainEvent> DomainEvents => _domainEvents;
        public void AddDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents = _domainEvents ?? new List<IDomainEvent>();
            _domainEvents.Add(eventItem);
        }
        public void RemoveDomainEvent(IDomainEvent eventItem)
        {
            if (_domainEvents is null) return;
            _domainEvents.Remove(eventItem);
        }


    }
}
