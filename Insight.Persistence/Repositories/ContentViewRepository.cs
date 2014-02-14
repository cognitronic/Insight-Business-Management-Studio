using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using Insight.Core.Interfaces;
using Insight.Core.Interfaces.Data;
using Insight.Core.Domain;
using IdeaSeed.Core.Data;
using IdeaSeed.Core.Data.NHibernate;

namespace Insight.Persistence.Repositories
{
    public class ContentViewRepository : BaseRepository<Insight.Core.Domain.ContentView, int>, IContentViewRepository
    {
        public IList<ContentView> GetByViewName(string viewName)
        {
            return  Session.CreateCriteria<ContentView>()
                .Add(Expression.Eq("ViewName", viewName))
                .List<ContentView>();
        }
    }
}
