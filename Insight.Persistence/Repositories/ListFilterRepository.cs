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
    public class ListFilterRepository : BaseRepository<BaseListFilter, int>, IListFilterRepository
    {
        public BaseListFilter GetByNamePageIDUserID(string name, int pageID, int userID)
        {
            return Session.CreateCriteria<BaseListFilter>()
                .Add(Expression.Eq("Name", name))
                .Add(Expression.Eq("PageID", pageID))
                .Add(Expression.Eq("UserID", userID))
                .UniqueResult<BaseListFilter>();
        }
    }
}
