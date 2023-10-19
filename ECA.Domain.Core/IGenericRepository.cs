using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Domain.Core
{
    public interface IGenericRepository<TAggregateRoot,TId> where TAggregateRoot: AggregateRoot<TId>
    {
        IEnumerable<TAggregateRoot> Find(Expression<Func<TAggregateRoot>> expression);
        IEnumerable<TAggregateRoot> FindAsync(Expression<Func<TAggregateRoot>> expression);

        TAggregateRoot FindOne(Expression<Func<TAggregateRoot>> expression);
        TAggregateRoot FindOne(TId id);
        TAggregateRoot FindOneAsync(Expression<Func<TAggregateRoot>> expression);
        TAggregateRoot FindOneAsync(TId id);


    }
}
