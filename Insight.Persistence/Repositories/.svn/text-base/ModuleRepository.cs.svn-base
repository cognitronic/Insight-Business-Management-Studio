using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using Insight.Core.Domain.Interfaces;
using Insight.Core.Domain.Interfaces.Data;
using Insight.Core.Domain;
using IdeaSeed.Core.Data;
using IdeaSeed.Core.Data.NHibernate;

namespace Insight.Persistence.Repositories
{
    public class ModuleRepository : BaseRepository<Insight.Core.Domain.Module, int>, IModuleRepository
    {
        public IList<Module> GetByStatus(bool isActive)
        {
            return Session.CreateCriteria<Module>()
                .Add(Expression.Eq("IsActive", isActive))
                .List<Module>();
        }

    }
}
