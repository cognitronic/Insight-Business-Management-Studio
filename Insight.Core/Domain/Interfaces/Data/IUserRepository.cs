using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core.Data;
using Insight.Core.Domain;

namespace Insight.Core.Domain.Interfaces.Data
{
    public interface IUserRepository : IRepository<User, int>
    {
        User GetByEmail(string email);
    }
}
