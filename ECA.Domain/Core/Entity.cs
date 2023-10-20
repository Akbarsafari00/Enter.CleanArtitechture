
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Domain.Core
{
    // COMPATIBLE WITH ENTITY FRAMEWORK CORE (1.1 and later)
    public abstract class Entity<TId>
    {
        int? _requestedHashCode;
        TId _Id;
       
        public virtual TId Id
        {
            get
            {
                return _Id;
            }
            protected set
            {
                _Id = value;
            }
        }

      
        public bool IsTransient()
        {
            return this.Id?.Equals(default(TId)) ?? false ;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity<TId>))
                return false;
            if (Object.ReferenceEquals(this, obj))
                return true;
            if (this.GetType() != obj.GetType())
                return false;
            Entity<TId> item = (Entity<TId>)obj;
            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item?.Id?.Equals(this.Id) ?? false;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31;
                // XOR for random distribution. See:
                // https://learn.microsoft.com/archive/blogs/ericlippert/guidelines-and-rules-for-gethashcode
                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }
        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null));
            else
                return left.Equals(right);
        }
        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !(left == right);
        }
    }
}
