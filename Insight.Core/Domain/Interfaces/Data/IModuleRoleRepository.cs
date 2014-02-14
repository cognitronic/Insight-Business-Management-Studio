using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core.Data;
using Insight.Core.Domain;

namespace Insight.Core.Domain.Interfaces.Data
{
    public interface IModuleRoleRepository : IRepository<ModuleRole, int>
    {
        IList<ModuleRole> GetByModuleID(int moduleID);
        ModuleRole GetByModuleIDAccessLevel(int moduleID, int accessLevel);
        ModuleRole GetByNameModuleID(string name, int moduleID);
    }
}
