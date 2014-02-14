using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using Insight.Core.Domain.Interfaces;
using Insight.Core.Domain.Interfaces.Data;
using Insight.Core.Domain;
using IdeaSeed.Core.Data;
using IdeaSeed.Core.Data.NHibernate;

namespace Insight.Persistence.Repositories
{
    public class PageApplicationViewRepository : BaseRepository<Insight.Core.Domain.PageApplicationView, int>, IPageApplicationViewRepository
    {
        public IList<PageApplicationView> GetByPageID(int pageID)
        {
            return Session.CreateCriteria<PageApplicationView>()
                .Add(Expression.Eq("PageID", pageID))
                .List<PageApplicationView>();
        }

        public PageApplicationView GetByPageIDApplicationViewID(int pageID, int appViewID)
        {
            return Session.CreateCriteria<PageApplicationView>()
                .Add(Expression.Eq("PageID", pageID))
                .Add(Expression.Eq("ApplicationViewID", appViewID))
                .UniqueResult<PageApplicationView>();
        }

        public IList<PageApplicationView> GetByApplicationViewID(int applicationViewID)
        {
            return Session.CreateCriteria<PageApplicationView>()
                .Add(Expression.Eq("ApplicationViewID", applicationViewID))
                .List<PageApplicationView>();
        }
    }
}
