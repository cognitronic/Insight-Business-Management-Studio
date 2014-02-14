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
    public class PageRepository : BaseRepository<Insight.Core.Domain.Page, int>, IPageRepository
    {
        public Insight.Core.Domain.Page GetByURL(string url)
        {
            return Session.CreateCriteria<Insight.Core.Domain.Page>()
                    .Add(Expression.Eq("URL", url))
                    .UniqueResult<Insight.Core.Domain.Page>();
        }

        public Insight.Core.Domain.Page GetByURLRoute(string urlRoute)
        {
            return Session.CreateCriteria<Insight.Core.Domain.Page>()
                    .Add(Expression.Eq("URLRoute", urlRoute))
                    .UniqueResult<Insight.Core.Domain.Page>();
        }

        public IList<Insight.Core.Domain.Page> GetChildPagesByParentID(int parentID, int navigationTypeID)
        {
            return Session.CreateCriteria<Insight.Core.Domain.Page>()
                    .Add(Expression.Eq("ParentID", parentID))
                    .Add(Expression.Eq("PageNavigationTypeID", navigationTypeID))
                    .List<Insight.Core.Domain.Page>();
        }

        public IList<Insight.Core.Domain.Page> GetChildPagesByParentID(int parentID)
        {
            return Session.CreateCriteria<Insight.Core.Domain.Page>()
                    .Add(Expression.Eq("ParentID", parentID))
                    .List<Insight.Core.Domain.Page>();
        }

        public IList<Insight.Core.Domain.Page> GetRootNodes()
        {
            return Session.CreateCriteria<Insight.Core.Domain.Page>()
                    .Add(Expression.IsNull("ParentID"))
                    .Add(Expression.Eq("PageNavigationTypeID", (int)PageNavigationType.PRIMARY))
                    .List<Insight.Core.Domain.Page>();
        }

        public PageUser GetPageUserByPageIDUserID(int pageID, int userID)
        {
            return Session.CreateCriteria<Insight.Core.Domain.PageUser>()
                    .Add(Expression.Eq("PageID", pageID))
                    .Add(Expression.Eq("UserID", userID))
                    .UniqueResult<Insight.Core.Domain.PageUser>();
        }

        public IList<PageUser> GetPageUsersByPageID(int pageID)
        {
            return Session.CreateCriteria<Insight.Core.Domain.PageUser>()
                    .Add(Expression.Eq("PageID", pageID))
                    .List<Insight.Core.Domain.PageUser>();
        }
    }
}
