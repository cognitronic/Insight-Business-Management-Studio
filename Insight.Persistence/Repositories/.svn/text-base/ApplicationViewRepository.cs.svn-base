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
    public class ApplicationViewRepository : BaseRepository<Insight.Core.Domain.ApplicationView, int>, IApplicationViewRepository
    {
        public ApplicationView GetByName(string name)
        {
            return Session.CreateCriteria<ApplicationView>()
                .Add(Expression.Eq("Name", name))
                .UniqueResult<ApplicationView>();
        }
    }
}
