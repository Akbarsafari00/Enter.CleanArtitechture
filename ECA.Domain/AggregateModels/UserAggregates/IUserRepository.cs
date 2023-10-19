using ECA.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Domain.AggregateModels.UserAggregates
{
    public interface IUserRepository : IGenericRepository<User,Guid>
    {

    }
}
