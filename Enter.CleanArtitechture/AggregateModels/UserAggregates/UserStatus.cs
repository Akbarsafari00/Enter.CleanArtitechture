using ECA.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Domain.AggregateModels.UserAggregates
{
    public class UserStatus : Enumeration
    {
        public static UserStatus Active = new UserStatus(0,nameof(Active));
        public static UserStatus DeActive = new UserStatus(0, nameof(DeActive));

        public UserStatus(int id, string name) : base(id, name)
        {
        }
    }
}
