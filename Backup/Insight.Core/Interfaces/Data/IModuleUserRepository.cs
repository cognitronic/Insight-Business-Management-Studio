using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core.Data;
using Insight.Core.Domain;

namespace Insight.Core.Interfaces.Data
{
    public interface IModuleUserRepository : IRepository<ModuleUser, int>
    {
        IList<ModuleUser> GetByModuleID(int moduleID);
        IList<IModuleUser> GetByUserID(int userID);
    }
}
